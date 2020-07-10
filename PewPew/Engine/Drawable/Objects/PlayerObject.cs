using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.CommandSystem.Commands;

using System.Collections.Generic;

namespace PewPew.Engine.Drawable.Objects
{
	public class PlayerObject : BaseObject
	{
		//private GameContent _GameContent = new GameContent();

		private BaseObject Generic;

		public PlayerObject() { }

		public BaseObject PlayerClone(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass)
		=> Generic.Clone(name, textureName, startPosition, mass, rows, columns);



	}
}