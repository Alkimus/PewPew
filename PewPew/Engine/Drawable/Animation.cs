using System;
using System.Collections.Generic;

namespace PewPew.Engine.Drawable
{
    public class Animation
    {
        private readonly List<int> _Indices = new List<int>();
        private int Index { get; set; }
        private int IndexPlus => Index + 1;

        private DateTime _LastUpdate;

        public int FPS { get; private set; }
        public string Name { get; private set; }

        public Animation(string name, List<int> indices, int fps)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            FPS = fps;
            _Indices = indices;
            _LastUpdate = DateTime.Now;
        }

        private bool TimeCheck()
        {
            var result = false;
            if (_LastUpdate + Increment <= DateTime.Now)
            {
                result = true;
                _LastUpdate = DateTime.Now;
            }
            return result;
        }

        private TimeSpan Increment => TimeSpan.FromMilliseconds(1000 / FPS);

        public int FrameIndex
        {
            get
            {
                Index = TimeCheck() ? IndexPlus >= _Indices.Count ? 0 : IndexPlus : Index;
                return _Indices[Index];
            }
        }
    }
}
