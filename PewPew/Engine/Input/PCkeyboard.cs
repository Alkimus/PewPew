using Microsoft.Xna.Framework.Input;

namespace PewPew.Engine.Input
{
	public class PCkeyboard
	{
		public KeyboardState LastKeyState;

		public void Update()
		{
			LastKeyState = Keyboard.GetState();
		}
	}
}