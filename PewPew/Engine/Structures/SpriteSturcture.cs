using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable;

using System;

namespace PewPew.Engine.Structures
{
	public struct SpriteSturcture : IEquatable<SpriteSturcture>
	{
		private readonly int _Rows;
		private readonly int _Columns;
		private readonly string _Name;
		private readonly SpriteSheet _SpriteSheet;

		public Texture2D Texture => _SpriteSheet.Texture;
		
		public string GetName => _Name;
		public int GetRows => _Rows;
		public int GetColumns => _Columns;

		public SpriteSturcture(
			string name, string textureName, int spriteSheetRows, int spriteSheetColumns)
		{
			_Name = name;
			_Rows = spriteSheetRows;
			_Columns = spriteSheetColumns;
			_SpriteSheet = new SpriteSheet(textureName, spriteSheetRows, spriteSheetColumns);
		}

		public Rectangle Bounds => _SpriteSheet.SourceRectangle;
		public Vector2 Center => _SpriteSheet.SourceRectangle.Center.ToVector2();  // Center of Sprite
		public float Bottom => _SpriteSheet.SourceRectangle.Bottom; // Only the Y axis, indicates the bottom of sprite
		public float Top => _SpriteSheet.SourceRectangle.Top; // Only the Y axis, indicates the top of sprite
		public float Right => _SpriteSheet.SourceRectangle.Right; //Only the X axis, indicates the Right of sprite
		public float Left => _SpriteSheet.SourceRectangle.Left;  //Only the X axis, indicates the Left of sprite

		public Rectangle SourceRectangle => _SpriteSheet.SourceRectangle;

		public void SetIndex(int index) => _SpriteSheet.SetIndex(index);

		#region Equatable

		public override bool Equals(object obj)
			=> obj is SpriteSturcture @object
			   && _Name == @object._Name
			   && _SpriteSheet == @object._SpriteSheet;

		public bool Equals(SpriteSturcture other)
			=> _SpriteSheet == other._SpriteSheet
			   && _Name == other._Name;

		public override int GetHashCode()
		{
			int hashCode = 639005060;
			hashCode = hashCode * -1521134295 + _SpriteSheet.GetHashCode();
			hashCode = hashCode * -1521134295 + _Name.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(SpriteSturcture left, SpriteSturcture right)
			=> left.Equals(right);

		public static bool operator !=(SpriteSturcture left, SpriteSturcture right)
			=> !(left == right);

		#endregion Equatable
	}
}