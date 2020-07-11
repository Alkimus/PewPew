using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.CommandSystem;
using PewPew.Engine.Structures;

namespace PewPew.Engine.Drawable.Objects
{
	public class BaseObject
	{
		public BaseObject(string name, string textureName, int rows, int columns, Vector2 startPosition, float mass, Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer, Animation animation, object sender)
		{
			SpriteInit(name, textureName, rows, columns);
			AnimationInit(animation);
			CommandInit(sender);
			MotionInit(startPosition, mass);
			DrawInit(scale, layerDepth, tint, effects, scaleModifer);
		}

		public virtual void Update()
		{
			if (_AnimationStructInit) UpdateAnimation();
			if (_CommandStructInit) UpdateCommand();
			if (_MotionStructInit) UpdateMotion();
			if (_SpriteStructInit) UpdateSprite();
			if (_DrawStructInit) UpdateDraw();
		}

		public virtual BaseObject Clone(string name, string textureName, Vector2 startPosition, float mass, int rows, int columns)
		{
			var clone = (BaseObject)MemberwiseClone();

			clone.AnimationStruct = _AnimationStructInit ? new AnimationStructure(AnimationStruct.GetAllAnimations) : new AnimationStructure();
			clone.CommandStruct = _CommandStructInit ? new CommandStructure(clone) : new CommandStructure();
			clone.MotionStruct = _MotionStructInit ? new MotionStructure(startPosition, mass) : new MotionStructure();
			clone.SpriteStruct = _SpriteStructInit ? new SpriteSturcture(name, textureName, rows, columns) : new SpriteSturcture();
			clone.DrawStruct = _DrawStructInit ? new DrawStructure(Vector2.One, 0, Color.White, SpriteEffects.None, 0.0f) : new DrawStructure();

			return clone;
		}


		#region Sprite Structure
		// ***********************************************************************************************************

		private SpriteSturcture _SpriteStruct;
		private bool _SpriteStructInit;
		
		internal SpriteSturcture SpriteStruct { get => _SpriteStruct; set => _SpriteStruct = value; }

		internal void SpriteInit(string name, string textureName, int rows, int columns)
		{
			_SpriteStruct = new SpriteSturcture(name, textureName, rows, columns);
			_SpriteStructInit = true;
		}

		public string SpriteName => _SpriteStruct.Name;

		public Texture2D SpriteTexture => _SpriteStruct.Texture;
		public Rectangle SpriteBounds => _SpriteStruct.SourceRectangle;
		public Vector2 SpriteCenter => _SpriteStruct.Center;
		public float SpriteBottom => _SpriteStruct.Bottom;


		public void SpriteSetIndex(int index) => _SpriteStruct.SetIndex(index);

		internal virtual void UpdateSprite()
		{
			/// TODO: add logic for Textures
		}


		// ***********************************************************************************************************
		#endregion Sprite Structure

		#region Draw Structure
		// ***********************************************************************************************************

		private DrawStructure _DrawStruct;
		private bool _DrawStructInit;

		internal DrawStructure DrawStruct { get => _DrawStruct; set => _DrawStruct = value; }

		internal void DrawInit(Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer)
		{
			_DrawStruct = new DrawStructure(scale, layerDepth, tint, effects, scaleModifer);
			_DrawStructInit = true;
		}

		public void DrawDepth(float depth) => _DrawStruct.LayerDepth = depth;
		public void DrawScale(Vector2 scale) => _DrawStruct.Scale = scale;

		public void DrawScaleModifer(float modifer) => _DrawStruct.ScaleModifer = modifer;

		public void DrawTint(Color tint) => _DrawStruct.Tint = tint;

		public void DrawEffects(SpriteEffects effects) => _DrawStruct.Effects = effects;

		internal virtual void UpdateDraw()
		{
			/// TODO: add logic for drawing
		}

		// ***********************************************************************************************************
		#endregion Draw Structure

		#region Motion Structure
		// ***********************************************************************************************************

		private MotionStructure _MotionStruct;
		private bool _MotionStructInit;

		internal MotionStructure MotionStruct { get => _MotionStruct; set => _MotionStruct = value; }

		internal void MotionInit(Vector2 currentPosition, float mass)
		{
			_MotionStruct = new MotionStructure(currentPosition, mass);
			_MotionStructInit = true;
		}

		internal virtual void UpdateMotion()
		{
			/// TODO: add logic for moving
		}


		// ***********************************************************************************************************
		#endregion Motion Structure

		#region Command Structure
		// ***********************************************************************************************************

		private CommandStructure _CommandStruct;
		private bool _CommandStructInit;

		internal CommandStructure CommandStruct { get => _CommandStruct; set => _CommandStruct = value; }

		internal void CommandInit(object sender)
		{
			_CommandStruct = new CommandStructure((BaseObject)sender);
			_CommandStructInit = true;
		}

		public void CommandAdd(Command command) => CommandStruct.AddCommand(command);

		public void CommandRemove(Command command) => CommandStruct.RemoveCommand(command);

		public void CommandRun(string name) => CommandStruct.RunCommand(name);

		public void CommandRunAll() => CommandStruct.RunAll();

		internal virtual void UpdateCommand()
		{
			_CommandStruct.RunAll();
		}


		// ***********************************************************************************************************
		#endregion Command Structure

		#region Animation Structure
		// ***********************************************************************************************************

		private AnimationStructure _AnimationStruct;
		private bool _AnimationStructInit;

		internal AnimationStructure AnimationStruct
		{ get => _AnimationStruct; set => AnimationStruct = value; }

		internal void AnimationInit(Animation animation)
		{
			_AnimationStruct = new AnimationStructure(animation);
			_AnimationStructInit = true;
		}

		public void AnimationAdd(Animation animation)
			=> AnimationStruct.AddAnimation(animation);

		public void AnimationRemove(string name)
			=> AnimationStruct.RemoveAnimation(name);

		public void AnimationStart() => AnimationStruct.StartAnimation();

		public void AnimationStop() => AnimationStruct.StopAnimation();

		public void AnimationSwitch(string name)
			=> AnimationStruct.SwitchAnimation(name);

		internal virtual void UpdateAnimation()
		{
			SpriteStruct.SetIndex(AnimationStruct.Index);
		}


		// ***********************************************************************************************************
		#endregion Animation Structure

	}
}