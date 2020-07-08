using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

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

        public override void ExecuteFirst(in BaseObject sender)
        {
            if (sender != null) base.ExecuteFirst(sender);
            if (!Destroy) sender.Update();
        }
    }
}
