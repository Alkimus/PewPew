using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem
{
	public class Command : ICommand
	{
		public string Name { get; set; }
		public bool Destroy { get; private set; }
		public bool RunOnce { get; set; }
		public int Iteration { get; private set; }

		internal BaseObject Sender;

		public Command(string name, bool runOnce)
			=> (Name, RunOnce, Destroy, Iteration) = (name, runOnce, false, 0);

		public virtual void ExecuteFirst(in BaseObject sender)
		{
			Sender = sender;
			if (ScheduleDeletion) Destroy = true;
			else Iteration++;
			ExecuteAfter();
		}

		public virtual void ExecuteAfter()
		{
		}

		private bool ScheduleDeletion { get => RunOnce && Iteration != 0; }
	}
}