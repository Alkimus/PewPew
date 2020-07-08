using PewPew.Engine.Drawable;
using PewPew.Engine.Drawable.Objects;

namespace PewPew.Engine.CommandSystem
{
    public class Invoker
    {
        private BaseObject _Sender;

        public Invoker(in BaseObject sender) 
            => _Sender = sender;

        public void Invoke(ICommand cmd) 
            => cmd.Execute(_Sender);
    }
}
