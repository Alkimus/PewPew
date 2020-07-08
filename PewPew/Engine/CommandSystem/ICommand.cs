using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem
{
    public interface ICommand
    {
        public void Execute(in BaseObject sender);
    }
}
