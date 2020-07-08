using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.CommandSystem.Commands;

using System.Collections.Generic;

namespace PewPew.Engine.Drawable.Objects
{
    public class PlayerObject
    {
        //private GameContent _GameContent = new GameContent();

        private string _Name;
        private int _FrameIndex;
        private Vector2 _Scale;
        private GameObject Generic;
        private Animation ColorCycle;

        public PlayerObject(string name, int frameindex, Vector2 scale)
        {
            (_Name, _FrameIndex, _Scale) = (name, frameindex, scale);
            ColorCycle = new Animation("ColorCycle", new List<int> { 1, 2, 3, 4, 5, 6 }, 3);
            Generic = new GameObject(name);
        }

        public GameObject Player(Texture2D texture)
        {
            GameObject Player = Generic.Clone(_Name, texture, 2, 3);
            Player.AddAnimation(ColorCycle);
            Player.Scale = _Scale;
            Player.LayerDepth = 0f;
            Player.AddCommand(new SetSpriteFrame("SetFrame", true, _FrameIndex));
            
            Player.AddCommand(new Move("EnableMove", false));
            return Player;
        }
    }
}
