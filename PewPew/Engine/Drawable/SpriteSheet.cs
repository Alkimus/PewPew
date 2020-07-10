using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace PewPew.Engine.Drawable
{
	public class SpriteSheet
	{
		public Texture2D Texture { get; private set; }
		public int Rows { get; private set; }
		public int Columns { get; private set; }
		public bool SingleSprite { get; private set; }
		public List<Rectangle> Frames { get; private set; }
		public int Frameindex { get; private set; }

		public SpriteSheet()
		{
		}

		public SpriteSheet(string textureName, int rows = 0, int columns = 0) => Fill(textureName, rows, columns);

		public void Fill(string texture, int rows = 0, int columns = 0)
		{
			Frames = new List<Rectangle>();
			Texture = GameContent.GetTexture(texture);
			Rows = rows;
			Columns = columns;
			SingleSprite = (rows == 0 || columns == 0);
			Frames.Add(Texture.Bounds);
			Frameindex = 0;

			if (SingleSprite) return;
			ParseSprite();
		}

		public Rectangle SourceRectangle
		{ get => SingleSprite ? Texture.Bounds : Frames[Frameindex]; set => SourceRectangle = value; }

		public void SetIndex(int index)
			=> Frameindex = index < Frames.Count && index >= 0 ? index : Frameindex;

		private void ParseSprite()
		{
			int width = SourceRectangle.Width / Columns;
			int height = SourceRectangle.Height / Rows;

			for (int y = 0; y < Rows; y++)
			{
				for (int x = 0; x < Columns; x++)
				{
					Frames.Add(
						new Rectangle(
							x * width,
							y * height,
							width,
							height
							)
						);
				}
			}
		}
	}
}