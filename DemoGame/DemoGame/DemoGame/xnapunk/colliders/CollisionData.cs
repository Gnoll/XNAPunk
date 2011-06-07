using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace xnapunk.colliders
{
    public class CollisionData
    {
        public Vector2 Intersection, Normal;
        public float Penetration;
        public Collider Collider;
    }
}
