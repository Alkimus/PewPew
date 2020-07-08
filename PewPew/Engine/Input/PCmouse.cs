using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PewPew.Engine.Input
{
    class PCmouse
    {
        private MouseState LastMouseState;

        public void Update()
        {
            LastMouseState = Mouse.GetState();
        }

        public bool LeftClick => Mouse.GetState().LeftButton == ButtonState.Pressed;
        public bool RightClick => Mouse.GetState().RightButton == ButtonState.Pressed;
        public bool NewClickLeft => LeftClick && LastMouseState.LeftButton == ButtonState.Released;
        public bool NewClickRight => RightClick && LastMouseState.RightButton == ButtonState.Released;
        public float Zoom => Mouse.GetState().ScrollWheelValue > LastMouseState.ScrollWheelValue ? 0.1f
            : Mouse.GetState().ScrollWheelValue == LastMouseState.ScrollWheelValue ? 0f : -0.1f;
        public float Spin => RightClick && Mouse.GetState().X > LastMouseState.X ? 0.1f
            : RightClick && Mouse.GetState().X == LastMouseState.X ? 0f : -0.1f;
    }
}
