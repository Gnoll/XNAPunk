using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace xnapunk.colliders
{
    class CircleCollider : Collider
    {

        public float Radius;

        public CircleCollider(float radius, Vector2 offset)
            : base(offset)
        {
            Radius = radius;
        }

        public override Collider.ColliderType Type() { return ColliderType.Circle; }

        public override bool IntersectsPoint(Vector2 point)
        {
            Vector2 ePos = Entity.Position;
            return (XP.Distance(ePos.X, ePos.Y, point.X, point.Y) < Radius);
        }

        public override bool IntersectsLine(Vector2 start, Vector2 end, float lineWidth)
        {
            Vector2 ePos = Entity.Position;
            
            Vector2 dir = end - start;
            Vector2 diff = (ePos + Offset) - start;
            float t = Vector2.Dot(diff, dir) / (dir.X * dir.X + dir.Y * dir.Y);
            if (t < 0.0f)
                t = 0.0f;
            if (t > 1.0f)
                t = 1.0f;
            Vector2 closest = (t * dir) + start;
            Vector2 d = (ePos + Offset) - closest;

            bool didCollide = (d.X * d.X + d.Y * d.Y) <= (Radius + lineWidth) * (Radius + lineWidth);
            
            return didCollide;
        }


        public float GetCenterX()
	    {
			return Entity.Position.X + Offset.X;
	    }

        public float GetCenterY()
	    {
            return Entity.Position.Y + Offset.Y;
	    }

        public Vector2 GetCenter()
	    {
		    return new Vector2(GetCenterX(), GetCenterY());
	    }

    }
}
