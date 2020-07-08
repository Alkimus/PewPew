using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem.Commands
{
    public class Move : Command
    {
        public Move(string name, bool runOnce)
            : base(name, runOnce) { }

        public override void ExecuteFirst(in BaseObject sender)
        {
            if (sender != null) base.ExecuteFirst(sender);
            if (!Destroy) sender.MotionStruct.Update();
        }

    }

}
