using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine;
using PewPew.Engine.CommandSystem.Commands;
using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;
using PewPew.Engine.Logs;
using PewPew.Engine.Structures;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PewPew
{
	public class GameWindow : Game
	{
		private GraphicsDeviceManager graphics;
		private Dictionary<string, BaseObject> Drawables;
		private SpriteBatch spriteBatch;

		private Vector2 Center;


		public GameWindow()
		{
			Pine.AddEntry(new Entry
			{
				SenderName = this.ToString(),
				DateStamp = DateTime.Now,
				EntryType = MessageType.Info, 
				EntryMessage = "New Game Window Started"
			});
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

			IsMouseVisible = true;
			Drawables = new Dictionary<string, BaseObject>();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
			
			GameServices.AddService<GraphicsDevice>(graphics.GraphicsDevice);
			GameServices.AddService<SpriteBatch>(spriteBatch);
			GameServices.AddService<ContentManager>(Content);

			SpriteSturcture spriteSturcture = new SpriteSturcture("player", "Player", 2, 3);
			MotionStructure motionStructure = new MotionStructure(Center, 300f);
			DrawStructure drawStructure = new DrawStructure(Vector2.One, 0f, Color.White, SpriteEffects.None, 1.0f);
			Animation animation = new Animation("Flash", new List<int> { 1, 2, 3, 4, 5, 6 }, 10);
			AnimationStructure animationStructure = new AnimationStructure(animation);

			GameObject gameObject = new GameObject(spriteSturcture, motionStructure, drawStructure, animationStructure);
			GameContent.AddObject(gameObject);
		}

		protected override void UnloadContent()
		{
			Drawables.Clear();
		}

		protected override void Update(GameTime gameTime)
		{
			if (!Drawables.ContainsKey("Player"))
			{
				Drawables["Player"] = GameContent.GetObject("player");
				Drawables["Player"].CommandAdd(new SetRelationalPosition("ToCenter", true, Center, Vector2.Zero));
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
				Drawables[name].Draw();
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}