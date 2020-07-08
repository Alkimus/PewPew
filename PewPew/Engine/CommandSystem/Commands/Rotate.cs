using PewPew.Engine.Drawable;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class Rotate : Command
    {
        public Rotate(string name, bool runOnce)
            : base(name, runOnce) { }

        public override void Execute(in GameObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.Rotation += sender.RotationalVelocity;
        }

    }

}
