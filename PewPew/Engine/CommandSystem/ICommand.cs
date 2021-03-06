﻿using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem
{
	public interface ICommand
	{
		public void ExecuteFirst(in BaseObject sender);

		public void ExecuteAfter();
	}
}