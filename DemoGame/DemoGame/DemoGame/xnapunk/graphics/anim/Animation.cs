using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xnapunk.graphics.anim
{

    public class Animation
    {
        public String Name;
        public bool Loop = true;
        public List<Frame> Frames = new List<Frame>();

        public Animation(bool loop, params Frame[] frames)
        {
            Loop = loop;
            foreach (Frame frame in frames)
                Frames.Add(frame);
        }

    }

    public class Frame
    {
        public int Index, Delay;

        public Frame(int index, int delay) { Index = index; Delay = delay; }
        public Frame(int index) { Index = index; Delay = 0; }

    }

}
