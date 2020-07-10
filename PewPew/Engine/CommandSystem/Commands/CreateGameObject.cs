using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem.Commands
{
	internal class CreateGameObject : Command
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