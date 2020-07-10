using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Structures;

namespace PewPew.Engine.Drawable.Objects
{
	public class BaseObject
	{
		private SpriteSturcture _SpriteStruct;
		private bool _SpriteStructInit;

		private DrawStructure _DrawStruct;
		private bool _DrawStructInit;

		private MotionStructure _MotionStruct;
		private bool _MotionStructInit;

		private CommandStructure _CommandStruct;
		private bool _CommandStructInit;

		private AnimationStructure _AnimationStruct;
		private bool _AnimationStructInit;

		public BaseObject(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass, Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer, Animation animation)
		{
			SpriteInit(name, textureName, rows, columns);
			AnimationInit(animation);
			CommandInit();
			MotionInit(startPosition, mass);
			DrawInit(scale, layerDepth, tint, effects, scaleModifer);
		}

		private void AnimationInit(Animation animation)
		{
			_AnimationStruct = new AnimationStructure(animation);
			_AnimationStructInit = true;
		}

		private void CommandInit()
		{
			_CommandStruct = new CommandStructure(this);
			_CommandStructInit = true;
		}

		private void MotionInit(Vector2 currentPosition, float mass)
		{
			_MotionStruct = new MotionStructure(currentPosition, mass);
			_MotionStructInit = true;
		}

		private void SpriteInit(string name, string textureName, int rows, int columns)
		{
			_SpriteStruct = new SpriteSturcture(name, textureName, rows, columns);
			_SpriteStructInit = true;
		}

		private void DrawInit(Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer)
		{
			_DrawStruct = new DrawStructure(scale, layerDepth, tint, effects, scaleModifer);
			_DrawStructInit = true;
		}

		private SpriteSturcture SpriteStruct { get => _SpriteStruct; set => _SpriteStruct = value; }

		private DrawStructure DrawStruct { get => _DrawStruct; set => _DrawStruct = value; }

		private MotionStructure MotionStruct { get => _MotionStruct; set => _MotionStruct = value; }

		private CommandStructure CommandStruct { get => _CommandStruct; set => _CommandStruct = value; }

		private AnimationStructure AnimationStruct { get => _AnimationStruct; set => AnimationStruct = value; }

		public virtual void Update()
		{
			if (_AnimationStructInit) AnimateUpdate();
			if (_CommandStructInit) CommandUpdate();
			if (_MotionStructInit) MotionUpdate();
			if (_SpriteStructInit) SpriteUpdate();
			if (_DrawStructInit) DrawUpdate();
		}

		private void SpriteUpdate()
		{
		}

		private void AnimateUpdate()
		{
			SpriteStruct.SetIndex(AnimationStruct.Index);
		}

		private void CommandUpdate()
		{
			_CommandStruct.RunAll();
		}

		private void MotionUpdate()
		{
		}

		private void DrawUpdate()
		{
		}

		public BaseObject Clone(string name, string textureName, Vector2 startPosition, float mass, int rows, int columns)
		{
			var clone = (BaseObject)MemberwiseClone();

			clone.AnimationStruct = _AnimationStructInit ? new AnimationStructure(AnimationStruct.GetAllAnimations) : new AnimationStructure();
			clone.CommandStruct = _CommandStructInit ? new CommandStructure(clone) : new CommandStructure();
			clone.MotionStruct = _MotionStructInit ? new MotionStructure(startPosition, mass) : new MotionStructure();
			clone.SpriteStruct = _SpriteStructInit ? new SpriteSturcture(name, textureName, rows, columns) : new SpriteSturcture();
			clone.DrawStruct = _DrawStructInit ? new DrawStructure(Vector2.One, 0, Color.White, SpriteEffects.None, 0.0f) : new DrawStructure();
			
			return clone;
		}
	}
}