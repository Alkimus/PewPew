using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.CommandSystem;
using PewPew.Engine.Drawable.Objects;
using PewPew.Engine.Structures;

using System.Collections.Generic;
using System.Linq;

namespace PewPew.Engine.Drawable
{
    public class GameObject : BaseObject
    {
        private Dictionary<string, Command> _CommandQueue;
        private Dictionary<string, Animation> _Animations;
        private SpriteSturcture _SpriteStruct;
        private DrawStructure _DrawStruct;
        private MotionStructure _MoveStruct;
        private CommandStructure _CommandStruct;


        //       *******************************************

        public GameObject(string name)
        {
            _CommandQueue = new Dictionary<string, Command>();
            _Animations = new Dictionary<string, Animation>();
            _Structure = new DrawStructure
            {
                Name = name,
                Position = Vector2.Zero,
                Scale = Vector2.One,
                ScaleModifer = 1.0f,
                LayerDepth = 0f,
                Tint = Color.White,
                Effects = SpriteEffects.None
            };

            _Motion = new MotionStructure
            {
                LinearVelocity = Vector2.Zero,
                LinearForce = 0f,
                Rotation = 0f,
                RotationalVelocity = 0f,
                RotationalModifer = 0f,
                RotationalForce = 0f
            };

        }

        public GameObject(string name, Texture2D texture, int rows, int columns)
        {
            _CommandQueue = new Dictionary<string, Command>();
            _Animations = new Dictionary<string, Animation>();
            _Structure = new DrawStructure
            {
                Name = name,
                SpriteSheet = new SpriteSheet(texture, rows, columns),
                Position = Vector2.Zero,
                Scale = Vector2.One,
                ScaleModifer = 1.0f,
                LayerDepth = 0f,
                Tint = Color.White,
                Effects = SpriteEffects.None
            };

            _Motion = new MotionStructure
            {
                LinearVelocity = Vector2.Zero,
                LinearForce = 0f,
                Rotation = 0f,
                RotationalVelocity = 0f,
                RotationalModifer = 0f,
                RotationalForce = 0f
            };
        }


        //       *******************************************


        private MotionStructure _Motion = new MotionStructure
        {
            LinearVelocity = Vector2.Zero,
            LinearForce = 0f,
            Rotation = 0f,
            RotationalVelocity = 0f,
            RotationalModifer = 0f,
            RotationalForce = 0f
        };

        public MotionStructure MovableStructure
        { get => _Motion; set => _Motion = value; }

        public Vector2 LinearVelocity
        { get => _Motion.LinearVelocity; set => _Motion.LinearVelocity = value; }
        public float RotationalVelocity
        { get => _Motion.RotationalVelocity; set => _Motion.RotationalVelocity = value; }
        public float Rotation
        { get => _Motion.Rotation; set => _Motion.Rotation = value; }
        public float LinearForce
        { get => _Motion.LinearForce; set => _Motion.LinearForce = value; }
        public float RotationalForce
        { get => _Motion.RotationalForce; set => _Motion.RotationalForce = value; }
        public float RotationalModifer
        { get => _Motion.RotationalModifer; set => _Motion.RotationalModifer = value; }

        //       *******************************************


        private DrawStructure _Structure = new DrawStructure
        {
            Name = "Default",
            SpriteSheet = new SpriteSheet(),
            Position = Vector2.Zero,
            Scale = Vector2.One,
            ScaleModifer = 1.0f,
            LayerDepth = 0f,
            Tint = Color.White,
            Effects = SpriteEffects.None
        };

        public DrawStructure Structure
        { get => _Structure; set => _Structure = value; }
        public string Name
        { get => _Structure.Name; set => _Structure.Name = value; }
        public Vector2 Position
        { get => _Structure.Position; set => _Structure.Position = value; }
        public SpriteSheet SpriteSheet
        { get => _Structure.SpriteSheet; set => _Structure.SpriteSheet = value; }
        public SpriteEffects Effects
        { get => _Structure.Effects; set => _Structure.Effects = value; }
        public Color Tint
        { get => _Structure.Tint; set => _Structure.Tint = value; }
        public float LayerDepth
        { get => _Structure.LayerDepth; set => _Structure.LayerDepth = value; }
        public Vector2 Scale
        { get => _Structure.Scale; set => _Structure.Scale = value; }
        public float ScaleModifer
        { get => _Structure.ScaleModifer; set => _Structure.ScaleModifer = value; }

        //       *******************************************


        private float CenterWidth
            => _Structure.SpriteSheet == null ? 0 : _Structure.SpriteSheet.SourceRectangle.Width / 2;
        private float CenterHeight
            => _Structure.SpriteSheet == null ? 0 : _Structure.SpriteSheet.SourceRectangle.Height / 2;
        private Vector2 Origin
            => new Vector2(CenterWidth, CenterHeight);
        public bool Destroy { get; set; }



        //       *******************************************



        private Invoker _CommandInvoker { get => new Invoker(this); set => _CommandInvoker = new Invoker(this); }
        private Dictionary<string, Command> _CommandQueue = new Dictionary<string, Command>();
        public void AddCommand(Command cmd) => _CommandQueue.Add(cmd.Name, cmd);
        private void RemoveCommand(string name) => _CommandQueue.Remove(name);
        public void ClearCommandQueue() => _CommandQueue.Clear();

        //       *******************************************


        private Dictionary<string, Animation> _Animations = new Dictionary<string, Animation>();

        private string AnimationKey { get; set; }
        private bool Animate { get; set; }
        public void AddAnimation(Animation animation) => _Animations.Add(animation.Name, animation);
        public void RemoveAnimation(string name) => _Animations.Remove(name);
        public void StopAnimation() => Animate = false;
        public void StartAnimation(string name)
        {
            Animate = true;
            AnimationKey = name;
        }


        //       *******************************************

        public void Update()
        {
            if (Animate)
                _Structure.SpriteSheet.SetIndex(_Animations[AnimationKey.ToString()].FrameIndex);

            for (int i = 0; i < _CommandQueue.Count; i++)
            {
                _CommandInvoker.Invoke(_CommandQueue.ElementAt(i).Value);

                if (_CommandQueue.ElementAt(i).Value.Destroy)
                    RemoveCommand(_CommandQueue.ElementAt(i).Key);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: _Structure.SpriteSheet.Texture,
                position: _Structure.Position,
                sourceRectangle: _Structure.SpriteSheet.SourceRectangle,
                origin: Origin,
                rotation: _Motion.Rotation * RotationalModifer,
                scale: _Structure.Scale * ScaleModifer,
                color: _Structure.Tint,
                effects: _Structure.Effects,
                layerDepth: _Structure.LayerDepth);
        }

        public GameObject Clone(string objectName, Texture2D textureName, int rows, int columns)
        {
            var _Clone = (GameObject)MemberwiseClone();

            _Clone._CommandStruct.CommandQueue = new Dictionary<string, Command>();
            _Clone._Animations = new Dictionary<string, Animation>();
            _Clone._CommandStruct = new CommandStructure();
            _Clone._DrawStruct = new DrawStructure()
            {
                Scale = Vector2.One,
                ScaleModifer = 1.0f,
                LayerDepth = 0f,
                Tint = Color.White,
                Effects = SpriteEffects.None
            };

            _Clone._MoveStruct = new MotionStructure
            {
                LinearVelocity = Vector2.Zero,
                LinearForce = 0f,
                Rotation = 0f,
                RotationalVelocity = 0f,
                RotationalModifer = 0f,
                RotationalForce = 0f
            };
            return _Clone;
        }


    }
}
