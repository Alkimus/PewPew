using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Structures;

using System.Linq;

namespace PewPew.Engine.Drawable.Objects
{
    public class BaseObject
    {
        private SpriteSturcture _SpriteStruct;
        private DrawStructure _DrawStruct;
        private MotionStructure _MotionStruct;
        private CommandStructure _CommandStruct;
        private AnimationStructure _AnimationStruct;

        public BaseObject()
        {
            _SpriteStruct = new SpriteSturcture();
            _DrawStruct = new DrawStructure();
            _MotionStruct = new MotionStructure();
            _CommandStruct = new CommandStructure();
            _AnimationStruct = new AnimationStructure();
        }

        public SpriteSturcture SpriteStruct { get => _SpriteStruct; set => _SpriteStruct = value; }
        public DrawStructure DrawStruct { get => _DrawStruct; set => _DrawStruct = value; }
        public MotionStructure MotionStruct { get => _MotionStruct; set => _MotionStruct = value; }
        public CommandStructure CommandStruct { get => _CommandStruct; set => _CommandStruct = value; }
        public AnimationStructure AnimationStruct { get => _AnimationStruct; set => AnimationStruct = value; }

        public virtual void Update()
        {
            SpriteStruct.SpriteSheet.SetIndex(AnimationStruct.Index);
            for (int i = 0; i < _CommandStruct.CommandQueue.Count; i++)
            {
                string name = _CommandStruct.CommandQueue.Keys.ElementAt(i);
                _CommandStruct.RunCommand(name);
            }
        }

    }
}
