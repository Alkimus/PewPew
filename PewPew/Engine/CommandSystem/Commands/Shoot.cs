using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class Shoot : Command
    {
        private Texture2D _Texture;
        public Shoot(string name, bool runOnce, Texture2D texture) 
            : base(name, runOnce)
        {
            _Texture = texture;
        }

        public override void Execute(in GameObject sender)
        {
            base.Execute(sender);
        }
    }
}
