using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace xnapunk.graphics
{
    public abstract class Graphic
    {

        public Vector2 Position, Size, Origin, Parallax = new Vector2(1,1);
        public Color Tint = Color.White;
        public float Rotation, Scale = 1.0f;
        public SpriteEffects Effects = SpriteEffects.None;

        public abstract void Draw(Vector2 position);

    }
}
