using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using xnapunk.graphics;
using Microsoft.Xna.Framework.Input;

namespace xnapunk.tools
{
    class Cursor : Entity
    {

        public Image Regular, Clicked;

        public Cursor(Image regular, Image clicked) : base(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), regular)
        {
            Layer = int.MaxValue;
            Regular = regular; Clicked = clicked;
            Regular.Parallax = new Vector2(); Clicked.Parallax = new Vector2();
        }

        public override void Update(GameTime gameTime)
        {
            Position.X = Mouse.GetState().X;
            Position.Y = Mouse.GetState().Y;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                Graphic = Clicked;
            else
                Graphic = Regular;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }        

    }
}
