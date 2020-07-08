using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PewPew.Engine.Input
{
    public class PCkeyboard
    {
        public KeyboardState LastKeyState;

        public void Update()
        {
            LastKeyState = Keyboard.GetState();
        }
    }
}
