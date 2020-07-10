using Microsoft.Xna.Framework;

using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.Drawable
{
	public class GameObject : BaseObject
	{
		private readonly BaseObject Generic = new BaseObject();

		public BaseObject GenericClone(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass)
			=> Generic.Clone(name, textureName, startPosition, mass, rows, columns);


	}
}