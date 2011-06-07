using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace xnapunk.graphics
{
    class SpriteMap : Graphic
    {

        private Texture2D Texture;

        private Rectangle SourceRect = new Rectangle();
        private int XCells, YCells;
        public int TotalFrames;
        private int _Frame = 0;
        public int Frame
        {
            get { return _Frame; }
            set
            {
                _Frame = value;
                while (_Frame >= TotalFrames) _Frame -= TotalFrames;

                SourceRect.X = (int)((_Frame % XCells) * Size.X);
                SourceRect.Y = (int)(Math.Floor((double)_Frame / XCells) * Size.Y);
            }
        }


        public SpriteMap(Texture2D texture, Vector2 frameSize)
        {
            Texture = texture;
            Size = frameSize;
            SourceRect.Width = (int)frameSize.X; SourceRect.Height = (int)frameSize.Y;

            XCells = (int)Math.Floor(Texture.Width / Size.X);
            YCells = (int)Math.Floor(Texture.Height / Size.Y);
            TotalFrames = XCells * YCells;

        }

        override public void Draw(Vector2 position)
        {
            XP.Canvas.Draw(Texture, position + Position - XP.Camera.Position * Parallax, SourceRect, Tint, Rotation, Origin, Scale, Effects, 0);
        }

        public void CentreOrigin()
        {
            Origin.X = Texture.Width / 2; Origin.Y = Texture.Height / 2;
        }

    }
}
