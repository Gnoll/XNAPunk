using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xnapunk;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using demogame.entities;
using xnapunk.tools;
using xnapunk.graphics;

namespace demogame
{
    public class ExampleWorld2 : World
    {

        private Text Counter = new Text("");

        public ExampleWorld2()
        {
            AddGraphic(XP.Load("Background"));

            FPSText fps = new FPSText(new Vector2(20, 20));
            Add(fps);
            fps.Layer = 100;
            Entity counter = AddGraphic(Counter, 20, 50);
            counter.Layer = 100;

            XP.MouseVisible = false;
        }

        private float counter = 0;
        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < 300; i++)
            {
                MouseState m = Mouse.GetState();

                Particle p = new Particle(m.X, m.Y);
                Add(p);

                p.Velocity = new Vector2((float)Math.Cos(counter), (float)Math.Sin(counter)) * 5;

                counter += 0.05f;
            }

            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.Escape)) XP.World = new MainMenu();

            Counter.Txt = "Entities: " + EntityCount;

            base.Update(gameTime);
        }

    }
}
