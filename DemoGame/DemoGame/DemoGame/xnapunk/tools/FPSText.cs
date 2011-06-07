using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xnapunk.graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace xnapunk.tools
{
    class FPSText : Entity
    {

        private Text Txt = new Text("");

        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        public FPSText(Vector2 position) : base(position) { Graphic = Txt; Layer = int.MaxValue; }

        public FPSText(Vector2 position, SpriteFont font, Color color) : this(position)
        { 
            Txt.Font = font; Txt.Tint = color;
        }

        override public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            base.Update(gameTime);
        }

        override public void Draw(GameTime gameTime)
        {
            frameCounter++;

            Txt.Txt = string.Format("{0}fps", frameRate);

            base.Draw(gameTime);
        }

    }
}