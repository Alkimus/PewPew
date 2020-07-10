using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem.Commands
{
	internal class SetSpriteFrame : Command
	{
		private int FrameIndex;

		public SetSpriteFrame(string name, bool runOnce, int frameIndex) : base(name, runOnce)
		{
			FrameIndex = frameIndex;
		}

		public override void ExecuteFirst(in BaseObject sender)
		{
			if (sender != null) base.ExecuteFirst(sender);
			if (!Destroy) sender.SpriteStruct.SetIndex(FrameIndex);
		}
	}
}