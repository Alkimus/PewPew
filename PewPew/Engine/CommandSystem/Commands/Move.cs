using PewPew.Engine.Drawable;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class Move : Command
    {
        public Move(string name, bool runOnce)
            : base(name, runOnce) { }

        public override void Execute(in GameObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.Position += sender.LinearVelocity;
        }

    }

}
