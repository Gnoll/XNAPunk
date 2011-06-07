using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using xnapunk.graphics.anim;

namespace xnapunk.graphics
{
    class AnimatedSpriteMap : SpriteMap
    {
        public Dictionary<String, Animation> Animations = new Dictionary<String, Animation>();

        public Animation CurrentAnimation;
        private int Time, Index;

        public bool Playing = false;

        public AnimatedSpriteMap(Texture2D texture, Vector2 frameSize) : base(texture, frameSize) { }

        public void Play(String animation, bool reset)
        {
            if (CurrentAnimation == Animations[animation])
            {
                if (reset) { Index = 0; Time = 0; }
            }
            else
            {
                CurrentAnimation = Animations[animation]; Index = 0; Time = 0;
            }

            if (!CurrentAnimation.Loop && Index >= CurrentAnimation.Frames.Count) Index = 0;

            Playing = true;

        }

        public void Play(String animation)
        {
            Play(animation, false);
        }

        public void Update(GameTime gameTime)
        {
            if (!Playing) return;

            Time -= gameTime.ElapsedGameTime.Milliseconds;
            if (Time <= 0)
            {
                Frame f = CurrentAnimation.Frames[Index];
                Time = f.Delay;
                base.Frame = f.Index;

                Index++;
                if (CurrentAnimation.Loop && Index >= CurrentAnimation.Frames.Count)
                    Index = 0;
                else if (Index >= CurrentAnimation.Frames.Count)
                    Playing = false;
            }
        }

    }
}
