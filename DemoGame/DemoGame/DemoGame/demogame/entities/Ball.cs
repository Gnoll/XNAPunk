using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xnapunk;
using Microsoft.Xna.Framework;
using xnapunk.colliders;

namespace demogame.entities
{
    class Ball : Entity
    {

        public Vector2 Velocity = Vector2.Zero;

        public Ball(int x, int y)
            : base(new Vector2(x, y), XP.Load("Ball"))
        {
            //Offset the graphic to centre
            Graphic.Position = -Graphic.Size / 2;
            //Collision
            Collider = new CircleCollider(Graphic.Size.X / 2, Vector2.Zero);
            CollisionTags.Add("Ball");
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity; //multiply by gameTime.ElapsedGameTime.TotalSeconds for variable frame-rate

            //Keep in bounds and bounce
            if (Position.X < Graphic.Size.X / 2)
            {
                Position.X = Graphic.Size.X / 2; Velocity.X *= -1;
            }
            else if (Position.X > XP.Dimensions.X - Graphic.Size.X / 2)
            {
                Position.X = XP.Dimensions.X - Graphic.Size.X / 2; Velocity.X *= -1;
            } 
            if (Position.Y < Graphic.Size.Y / 2)
            {
                Position.Y = Graphic.Size.Y / 2; Velocity.Y *= -1;
            } if (Position.Y > XP.Dimensions.Y - Graphic.Size.Y / 2)
            {
                Position.Y = XP.Dimensions.Y - Graphic.Size.Y / 2; Velocity.Y *= -1;
            }

            base.Update(gameTime);
        }

    }
}
