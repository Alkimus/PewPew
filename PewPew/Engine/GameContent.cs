using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable.Objects;
using System.Xml;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PewPew.Engine.Drawable;

namespace PewPew.Engine
{
	public static class GameContent
	{
		private static ContentManager Content { get; set; }
		private static XmlDocument Config;
		private static bool Initialized;

		private static void InitializeContent()
		{
			Content = GameServices.GetService<ContentManager>();
			LoadTextures();
			Initialized = true;
		}

		private static Dictionary<string, Texture2D> Textures { get; set; }

		private static void LoadTextures()
		{
			Textures = new Dictionary<string, Texture2D>();
			Textures["Player"] = Content.Load<Texture2D>("Player");
			Textures.Add("Bullet", Content.Load<Texture2D>("Bullet"));
			Textures.Add("Debug", Content.Load<Texture2D>("Debug"));
			Textures.Add("Plume", Content.Load<Texture2D>("Plume"));
			Textures.Add("Star", Content.Load<Texture2D>("Star"));
			Textures.Add("font", Content.Load<Texture2D>("Fonts/Multivac"));
		}

		public static Texture2D GetTexture(string name)
		{
			if (!Initialized) InitializeContent();
			return Textures[name];
		}

		private static Dictionary<string, BaseObject> Objects { get; set; }

		public static void AddObject(GameObject addGameObject = null)
		{
			Objects = new Dictionary<string, BaseObject>();
			if (addGameObject == null) throw new System.Exception($"An attempt to load a GameObject failed, the constructor required an object");

			Objects[addGameObject.SpriteName] = addGameObject.GenericClone();
		}

		public static BaseObject GetObject(string name)
		{
			if (!Initialized) InitializeContent();
			if (Objects is null) throw new System.Exception($"An Attempt to GetObject(\"{name}\") failed because GameObjects is null");

			return Objects[name];
		}
	}
}