using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable;

using System;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class SetRotationalVelocity : Command
    {
        private readonly float _RotationalForce;

        public SetRotationalVelocity(string name, bool runOnce, float rotationalForce)
            : base(name, runOnce)
        {
            _RotationalForce = rotationalForce;
        }

        public override void Execute(in GameObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.RotationalVelocity = _RotationalForce;
        }

    }
}
