using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

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

        public override void ExecuteFirst(in BaseObject sender)
        {
            base.ExecuteFirst(sender);
        }
    }
}
