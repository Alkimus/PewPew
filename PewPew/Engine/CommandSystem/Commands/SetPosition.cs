using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem.Commands
{
	public class SetPosition : Command
	{
		private Vector2 _NewPosition;

		public SetPosition(string name, bool runOnce, Vector2 newPosition)
			: base(name, runOnce)
		{
			_NewPosition = newPosition;
		}

		public override void ExecuteFirst(in BaseObject sender)
		{
			if (sender != null) base.ExecuteFirst(sender);
			if (!Destroy) sender.Update();
		}
	}
}