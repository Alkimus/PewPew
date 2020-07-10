using Microsoft.Xna.Framework;

namespace PewPew.Engine
{
	public static class GameServices
	{
		public static GameServiceContainer Instance
		{
			get
			{
				if (Container is null)
				{
					Container = new GameServiceContainer();
				}

				return Container;
			}
		}

		public static GameServiceContainer Container { get; private set; }

		public static T GetService<T>() => (T)Instance.GetService(typeof(T));

		public static void AddService<T>(T service) => Instance.AddService(typeof(T), service);

		public static void RemoveService<T>() => Instance.RemoveService(typeof(T));
	}
}