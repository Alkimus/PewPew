using PewPew.Engine.Drawable;

namespace PewPew.Engine.CommandSystem.Commands
{
    class SetSpriteFrame : Command
    {
        private int FrameIndex;

        public SetSpriteFrame(string name, bool runOnce, int frameIndex) : base(name, runOnce)
        {
            FrameIndex = frameIndex;
        }

        public override void Execute(in GameObject sender)
        {
            if (sender != null) base.Execute(sender);
            if (!Destroy) sender.Structure.SpriteSheet.SetIndex(FrameIndex);
        }
    }
}
