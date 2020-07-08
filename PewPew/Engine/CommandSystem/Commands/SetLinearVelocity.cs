using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

using System;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class SetLinearVelocity : Command
    {
        private Vector2 DirectionalForce;

        public SetLinearVelocity(string name, bool runOnce, Vector2 directionalForce) 
            : base(name, runOnce)
        {
            DirectionalForce = directionalForce;
        }

        public override void Execute(in BaseObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.LinearVelocity = DirectionalForce;
        }
    }
}
