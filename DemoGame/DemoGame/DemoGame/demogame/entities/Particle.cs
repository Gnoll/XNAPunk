using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xnapunk;
using Microsoft.Xna.Framework;
using xnapunk.graphics;

namespace demogame.entities
{
    public class Particle : Entity
    {

        public Vector2 Velocity = Vector2.Zero;
        private static Image img = XP.Load("Particle");

        private static Rectangle bounds = new Rectangle(-50, -50, XP.Dimensions.X + 100, XP.Dimensions.Y + 100);

        public Particle(int x, int y)
            : base(new Vector2(x, y), img)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;

            if (!bounds.Contains((int)Position.X, (int)Position.Y)) XP.World.Remove(this);

            base.Update(gameTime);
        }

    }
}
