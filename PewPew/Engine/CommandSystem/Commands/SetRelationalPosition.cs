using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable;

using System;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class SetRelationalPosition : Command
    {
        private Vector2 _Origin;
        private Vector2 _Relational;

        public SetRelationalPosition(string name, bool runOnce, Vector2 origin, Vector2 relational) 
            : base(name, runOnce)
        {
            _Origin = origin;
            _Relational = relational;
        }

        public override void Execute(in GameObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.Position = Vector2.Add(_Origin, _Relational);
        }
    }
}
