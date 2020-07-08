using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PewPew.Engine.CommandSystem.Commands
{
    class CreateGameObject : Command
    {


        public CreateGameObject(string name, bool runOnce) 
            : base(name, runOnce)
        {

        }

        public override void ExecuteFirst(in BaseObject sender)
        {

            base.ExecuteFirst(sender);
        }
    }
}
