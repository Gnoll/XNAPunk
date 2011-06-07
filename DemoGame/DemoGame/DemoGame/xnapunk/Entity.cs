using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using xnapunk.graphics;
using xnapunk.colliders;

namespace xnapunk
{
    public class Entity
    {

        public Vector2 Position;
        public Graphic Graphic;
        public int Layer = 0;

        public bool Visible = true;

        private Collider _Collider;
        public Collider Collider
        {
            get { return _Collider; }
            set { _Collider = value; if (value != null) _Collider.Entity = this; }
        }

        public List<String> CollisionTags = new List<String>();

        

        public Entity(Vector2 position, Graphic graphic)
        {
            Graphic = graphic;
            Position = position;
        }

        public Entity(Vector2 position)
        {
            Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime)
        {
            if (Graphic != null && Visible) Graphic.Draw(Position);
        }

        public static int Compare(Entity e1, Entity e2)
        {
            return e1.Layer.CompareTo(e2.Layer);
        }

    }
}
