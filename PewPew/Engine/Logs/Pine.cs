using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PewPew.Engine.Logs
{

	public enum MessageType
	{
		Info,
		Warning,
		Error
	}

	public struct Entry
	{
		public string SenderName;
		public MessageType EntryType;
		public DateTime DateStamp;
		public string EntryMessage;

		public string EntryString 
			=> $"({DateStamp.DayOfWeek}:{DateStamp.Month}:{DateStamp.Day}:{DateStamp.TimeOfDay}:{DateStamp.Millisecond})" +
			   $" [{nameof(EntryType)}] {{ {SenderName} }} -> {EntryMessage}";
	}

	public static class Pine
	{
		private static Dictionary<int, Entry> Messages;

		static Pine()
		{
			Messages = new Dictionary<int, Entry>
			{
				{
					0,
					new Entry
					{
						DateStamp = DateTime.Now,
						EntryType = MessageType.Info,
						SenderName = "PineLog initialize Class",
						EntryMessage = "New Pine Log Created"
					}
				}
			};

		}

		public static void WriteLog(Entry message)
		{
			foreach (var item in Messages.Values)
			{
				Console.WriteLine(item.EntryString);
			}
			Messages.Clear();
		}

		public static void AddEntry(Entry message)
		{
			if (Messages is null)
			{
				Messages = new Dictionary<int, Entry>();
			}
			Messages.Add(Messages.Count, message);
		}

		public static void ThrowException(Entry message)
		{
			throw new Exception(message.EntryString);
		}
	}
}
