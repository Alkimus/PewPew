using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem
{
	public class Invoker
	{
		private BaseObject _Sender;

		public Invoker(in BaseObject sender)
			=> _Sender = sender;

		public void InvokeFirst(ICommand cmd)
		{
			cmd.ExecuteFirst(_Sender);
		}

		public void InvokeAfter(ICommand cmd)
		{
			cmd.ExecuteAfter();
		}
	}
}