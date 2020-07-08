using PewPew.Engine.Drawable;

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

        public override void Execute(in GameObject sender)
        {

            base.Execute(sender);
        }
    }
}
