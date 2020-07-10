using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable.Objects;

using System.Collections.Generic;

namespace PewPew.Engine
{
	public static class GameContent
	{
		private static ContentManager Content { get; set; }

		private static bool Initialized;

		private static void InitializeContent()
		{
			Content = GameServices.GetService<ContentManager>();
			LoadTextures();
			LoadObjects();
			Initialized = true;
		}

		private static Dictionary<string, Texture2D> Textures { get; set; }

		private static void LoadTextures()
		{
			Textures = new Dictionary<string, Texture2D>
			{
				{ "Player", Content.Load<Texture2D>("Player") },
				{ "Bullet", Content.Load<Texture2D>("Bullet") },
				{ "Debug", Content.Load<Texture2D>("Debug") },
				{ "Plume", Content.Load<Texture2D>("Plume") },
				{ "Star", Content.Load<Texture2D>("Star") },
				{ "font", Content.Load<Texture2D>("Fonts/Multivac") }
			};
		}

		public static Texture2D GetTexture(string name)
		{
			if (!Initialized) InitializeContent();
			return Textures[name];
		}

		private static Dictionary<string, BaseObject> Objects { get; set; }

		private static void LoadObjects()
		{
		}

		public static BaseObject GetObject(string name)
		{
			if (!Initialized) InitializeContent();
			if (Objects is null) throw new System.Exception($"An Attempt to GetObject(\"{name}\") failed because GameObjects is null");

			return Objects[name];
		}
	}
}