using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xnapunk;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using demogame.entities;

namespace demogame
{
    public class ExampleWorld : World
    {

        private Ball ball;
        private bool selected = false;

        public ExampleWorld()
        {
            AddGraphic(XP.Load("Background"));

            ball = new Ball(400, 300);
            Add(ball);

            XP.MouseVisible = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (!selected)
            {
                MouseState m = Mouse.GetState();
                if (m.LeftButton == ButtonState.Pressed) //is mouse down
                {
                    if (ball.Collider.IntersectsPoint(new Vector2(m.X, m.Y)))
                    {
                        ball.Velocity = new Vector2((float)XP.Rand.NextDouble() * 20 - 10,
                                                    (float)XP.Rand.NextDouble() * 20 - 10);
                        selected = true;
                    }
                }
            }

            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.Escape)) XP.World = new MainMenu();

            base.Update(gameTime);
        }

    }
}
