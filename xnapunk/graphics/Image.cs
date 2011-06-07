using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace xnapunk.graphics
{
    public class Image : Graphic
    {

        private Texture2D Texture;

        public Image(Texture2D texture)
        {
            Texture = texture;
            Size = new Vector2(texture.Width, texture.Height);
        }

        override public void Draw(Vector2 position)
        {
            XP.Canvas.Draw(Texture, position + Position - XP.Camera.Position * Parallax, null, Tint, Rotation, Origin, Scale, Effects, 0);
        }

        public void CentreOrigin()
        {
            Origin.X = Texture.Width / 2; Origin.Y = Texture.Height / 2;
        }

    }
}
