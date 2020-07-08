using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine;
using PewPew.Engine.CommandSystem;
using PewPew.Engine.CommandSystem.Commands;
using PewPew.Engine.Drawable;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PewPew
{
    public class GameWindow : Game
    {
        private GraphicsDeviceManager graphics;
        private GameContent GameContent;
        private Dictionary<string, GameObject> Drawables;
        private SpriteBatch spriteBatch;

        private DateTime updatetime = new DateTime();
        private int BulletsName;
        private int BulletCounter;
        private float GlobalZoom;
        private float GlobalRotation;
        private Vector2 Center;
        private bool BulletToggle;


        public GameWindow()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_Settings_NoDepthBuffer);


        }

        private void graphics_Settings_NoDepthBuffer(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DepthStencilFormat = DepthFormat.None;
        }

        protected override void Initialize()
        {
            base.Initialize();

            //graphics.ToggleFullScreen();

            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            Center = new Vector2(
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);

            GlobalZoom = 1.0f;
            GlobalRotation = 0f;
            IsMouseVisible = true;
            updatetime = DateTime.Now;
            Drawables = new Dictionary<string, GameObject>();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            GameServices.AddService<GraphicsDevice>(graphics.GraphicsDevice);
            GameServices.AddService<SpriteBatch>(spriteBatch);
            GameServices.AddService<ContentManager>(Content);
        }

        private GameObject AddBullet(string name)
        {

            Animation BulletAnim = new Animation("BulletAnim", new List<int> { 1, 2, 3, 4 }, 8);
            GameObject Generic = new GameObject(name);

            GameObject Bullet = Generic.Clone(name, GameContent.GetTexture("Bullet"), 1, 4);
            Bullet.AddAnimation(BulletAnim);
            Bullet.StartAnimation("BulletAnim");
            Bullet.Scale = new Vector2(0.5f, 0.5f);
            Bullet.LayerDepth = 1f;
            Bullet.AddCommand(new SetLinearVelocity("Push", false, new Vector2(0, -20)));
            Bullet.AddCommand(new Move("Move", false));

            if (BulletToggle)
            {
                Bullet.AddCommand(
                    new SetRelationalPosition(
                        "ToPlayer",
                        true,
                        Drawables["Player"].Position,
                        new Vector2(30, 0)));
                BulletToggle = false;
            }
            else
            {
                Bullet.AddCommand(
                    new SetRelationalPosition(
                        "ToPlayer",
                        true,
                        Drawables["Player"].Position,
                        new Vector2(-30, 0)));
                BulletToggle = true;
            }
            return Bullet;
        }


        protected override void UnloadContent()
        {
            Drawables.Clear();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!Drawables.ContainsKey("Player"))
            {

                Drawables["Player"] = GameContent.LoadObject(Center, "Player");
            }

            if (BulletCounter < 3 && updatetime.Ticks < DateTime.Now.Ticks)
            {
                BulletsName++;
                string name = $"Bullet{BulletsName}";
                Drawables[name] = AddBullet(name);
                BulletCounter++;
                updatetime = DateTime.Now + TimeSpan.FromMilliseconds(200);
            }

            for (int i = 0; i < Drawables.Count; i++)
            {
                string name = Drawables.Keys.ElementAt(i);

                Drawables[name].ScaleModifer = GlobalZoom;
                Drawables[name].RotationalModifer = GlobalRotation;
                Drawables[name].Update();

                if (Drawables[name].Destroy || Drawables[name].Position.Y <= -50)
                {
                    Drawables.Remove(name);
                    BulletCounter--;
                }

            }



            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront);

            for (int i = 0; i < Drawables.Count; i++)
            {
                string name = Drawables.Keys.ElementAt(i);
                Drawables[name].Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
