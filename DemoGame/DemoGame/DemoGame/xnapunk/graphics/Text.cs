using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace xnapunk.graphics
{
    class Text : Graphic
    {

        public SpriteFont Font = XP.Font;

        public String Txt = "";

        public Text(String txt)
        {
            Txt = txt;
            Size = Font.MeasureString(Txt);
        }

        public void MeasureString() { Size = Font.MeasureString(Txt); }

        public override void Draw(Vector2 position)
        {
            XP.Canvas.DrawString(Font, Txt, position + Position - XP.Camera.Position * Parallax, Tint, Rotation, Origin, Scale, Effects, 0);
        }

    }
}
