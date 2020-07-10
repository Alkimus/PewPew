using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem.Commands
{
	public class Rotate : Command
	{
		public Rotate(string name, bool runOnce)
			: base(name, runOnce) { }

		public override void ExecuteFirst(in BaseObject sender)
		{
			if (sender != null) base.ExecuteFirst(sender);
			if (!Destroy) sender.Update();
		}
	}
}