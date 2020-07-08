using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable;

using System;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class SetPosition : Command
    {
        private Vector2 _NewPosition;
        public SetPosition(string name, bool runOnce, Vector2 newPosition) 
            : base(name, runOnce)
        {
            _NewPosition = newPosition;
        }

        public override void Execute(in GameObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.Position = _NewPosition;
        }

    }

}
