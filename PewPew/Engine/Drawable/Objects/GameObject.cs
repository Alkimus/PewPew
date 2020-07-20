using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable.Objects;
using PewPew.Engine.Structures;

namespace PewPew.Engine.Drawable
{
	public class GameObject : BaseObject
	{
		private GameObject Generic;

		public GameObject(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass, Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer, Animation animation) : base(name, textureName, rows, columns, startPosition, mass, scale, layerDepth, tint, effects, scaleModifer, animation)
		{
			Generic = (GameObject)base.MemberwiseClone();
		}
		public GameObject(SpriteSturcture spriteSturcture, MotionStructure motionStructure, DrawStructure drawStructure, AnimationStructure animationStructure) : base(spriteSturcture, motionStructure, drawStructure, animationStructure) 
		{
			Generic = (GameObject)base.MemberwiseClone();
		}

		public BaseObject GenericClone()
			=> Generic;

		public override void Update()
		{
			base.Update();
		}
	}
}