using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.Drawable
{
	public class GameObject : BaseObject
	{
		private GameObject Generic;

		public GameObject(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass, Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer, Animation animation,object sender, BaseObject generic = null) : base(name, textureName, rows, columns, startPosition, mass, scale, layerDepth, tint, effects, scaleModifer, animation,sender)
		{
			Generic = (GameObject)generic;
		}

		public override BaseObject Clone(string name, string textureName, Vector2 startPosition, float mass, int rows, int columns)
		{
			return base.Clone(name, textureName, startPosition, mass, rows, columns);
		}

		public BaseObject GenericClone(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass)
			=> Generic.Clone(name, textureName, startPosition, mass, rows, columns);

		public override void Update()
		{
			base.Update();
		}
	}
}