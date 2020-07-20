using PewPew.Engine.CommandSystem;
using PewPew.Engine.Drawable.Objects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PewPew.Engine.Structures
{
	public struct CommandStructure : IEquatable<CommandStructure>
	{
	
		private Invoker CommandInvoker;
		private Dictionary<string, Command> CommandQueue;
		private BaseObject Sender;
		private bool Initialized;

		private void Initialize(in BaseObject sender)
		{
			Sender = sender;
			CommandInvoker = new Invoker(Sender);
			CommandQueue = new Dictionary<string, Command>();
			Initialized = true;
		}

		public CommandStructure(in BaseObject sender)
		{
			Sender = sender;
			CommandInvoker = new Invoker(Sender);
			CommandQueue = new Dictionary<string, Command>();
			Initialized = true;
		}

		public void AddCommand(Command command, in BaseObject sender)
		{
			if (!Initialized) Initialize(sender);
			CommandQueue.Add(command.Name, command);
		}

		public void AddCommand(Command command)
		{
			if (InitCheck(command.Name)) CommandQueue.Add(command.Name, command);
		}

		public void RemoveCommand(Command command)
		{
			if (InitCheck(command.Name)) CommandQueue.Remove(command.Name);
		}

		public void RunCommand(string commandName, in BaseObject sender)
		{
			if (!Initialized) Initialize(sender);
			CommandInvoker.InvokeFirst(CommandQueue[commandName]);
		}

		public void RunCommand(string commandName)
		{
			if (InitCheck(commandName)) CommandInvoker.InvokeFirst(CommandQueue[commandName]);
		}

		public void RunAll()
		{
			if (!Initialized)
			{
				string msg = $"{this} attempted to run all commands in queue but has not initialized yet.";
				Console.WriteLine(msg);
				throw new Exception(msg);
			}
			for (int i = 0; i < CommandQueue.Count; i++)
			{
				string name = CommandQueue.Keys.ElementAt(i);
				CommandInvoker.InvokeFirst(CommandQueue[name]);
				if (CommandQueue[name].Destroy) CommandQueue.Remove(name);
			}
		}

		private bool InitCheck(string commandName)
		{
			bool result = true;
			if (!Initialized)
			{
				Console.WriteLine($"{this} attempted to run command:{commandName}, but the Queue was not initialized");
				result = false;
			}
			if (Sender is null)
			{
				Console.WriteLine($"{this} attempted to run command:{commandName}, but no Sender was found.");
				result = false;
			}
			return result;
		}

		public bool Equals(CommandStructure other)
			=> CommandInvoker.Equals(other.CommandInvoker)
			   && CommandQueue.Equals(other.CommandQueue)
			   && Sender.Equals(other.Sender);

		public override bool Equals(object obj)
			=> obj is CommandStructure @object
			   && CommandInvoker.Equals(@object.CommandInvoker)
			   && CommandQueue.Equals(@object.CommandQueue)
			   && Sender.Equals(@object.Sender);

		public override int GetHashCode()
		{
			int hashCode = 639005060;
			hashCode = hashCode * -1521134295 + CommandQueue.GetHashCode();
			hashCode = hashCode * -1521134295 + CommandInvoker.GetHashCode();
			hashCode = hashCode * -1521134295 + Sender.GetHashCode();
			return hashCode;
		}
	}
}