using PewPew.Engine.CommandSystem;
using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

using System;
using System.Collections.Generic;

namespace PewPew.Engine.Structures
{
    public struct CommandStructure : IEquatable<CommandStructure>
    {
        public Invoker CommandInvoker;
        public Dictionary<string, Command> CommandQueue;

        private bool Initialized;
        private void Initialize(BaseObject sender)
        {
            CommandInvoker = new Invoker(sender);
            CommandQueue = new Dictionary<string, Command>();
            Initialized = true;
        }

        public void AddCommand(Command command, BaseObject sender)
        {
            if (!Initialized) Initialize(sender);
            CommandQueue.Add(command.Name, command);
        }
        public void AddCommand(Command command)
        {
            if (!Initialized)
            {
                Console.WriteLine($"{this} attempted to add command:{command.Name}, but the Queue was not initialized");
                return;
            }
            CommandQueue.Add(command.Name, command);
        }
        public void RemoveCommand(Command command, BaseObject sender)
        {
            if (!Initialized) Initialize(sender);
            CommandQueue.Remove(command.Name);
        }
        public void RemoveCommand(Command command)
        {
            if (!Initialized)
            {
                Console.WriteLine($"{this} attempted to remove command:{command.Name}, but the Queue was not initialized");
                return;
            }
            CommandQueue.Remove(command.Name);
        }
        public void RunCommand(string commandName, BaseObject sender)
        {
            if (!Initialized) Initialize(sender);
            CommandInvoker.Invoke(CommandQueue[commandName]);
        }
        public void RunCommand(string commandName)
        {
            if (!Initialized)
            {
                Console.WriteLine($"{this} attempted to run command:{commandName}, but the Queue was not initialized");
                return;
            }
            CommandInvoker.Invoke(CommandQueue[commandName]);
        }

        public bool Equals(CommandStructure other)
            => CommandInvoker.Equals(other.CommandInvoker)
               && CommandQueue.Equals(other.CommandQueue);
        public override bool Equals(object obj)
            => obj is CommandStructure @object
               && CommandInvoker.Equals(@object.CommandInvoker)
               && CommandQueue.Equals(@object.CommandQueue);
        public override int GetHashCode()
        {
            int hashCode = 639005060;
            hashCode = hashCode * -1521134295 + CommandQueue.GetHashCode();
            hashCode = hashCode * -1521134295 + CommandInvoker.GetHashCode();
            return hashCode;
        }
    }
}