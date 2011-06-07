using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace xnapunk.colliders
{
    public abstract class Collider
    {

        public bool CanCollide = true;

        public enum ColliderType
        {
            Rectangle, Circle, Polygon
        }

        public Entity Entity;

        public Vector2 Offset;

        public Collider() : this(Vector2.Zero) { }
        public Collider(Vector2 offset)
        {
            Offset = offset;
        }

        public abstract bool IntersectsPoint(Vector2 point);
        public abstract bool IntersectsLine(Vector2 start, Vector2 end, float lineWidth);

        public abstract ColliderType Type();

        public static bool Collide(Collider c1, Collider c2)
        {
            if (c1 == null || c2 == null) return false;
            ColliderType type1 = c1.Type(); ColliderType type2 = c2.Type();

            if (type1 == ColliderType.Rectangle && type2 == ColliderType.Rectangle)
                return CollideRectRect((RectangleCollider)c1, (RectangleCollider)c2);
            else if (type1 == ColliderType.Circle && type2 == ColliderType.Circle)
                return CollideCircCirc((CircleCollider)c1, (CircleCollider)c2);
            else if (type1 == ColliderType.Rectangle && type2 == ColliderType.Circle)
                return CollideRectCirc((RectangleCollider)c1, (CircleCollider)c2);
            else if (type1 == ColliderType.Circle && type2 == ColliderType.Rectangle)
                return CollideRectCirc((RectangleCollider)c2, (CircleCollider)c1);
            else return false;

        }

        public static bool LinesIntersect(Vector2 aStart, Vector2 aEnd, Vector2 bStart, Vector2 bEnd)
        {
            float d = ((bEnd.Y - bStart.Y) * (aEnd.X - aStart.X)) - ((bEnd.X - bStart.X) * (aEnd.Y - aStart.Y));
            float nX = ((bEnd.X - bStart.X) * (aStart.Y - bStart.Y)) - ((bEnd.Y - bStart.Y) * (aStart.X - bStart.X));
            float nY = ((aEnd.X - aStart.X) * (aStart.Y - bStart.Y)) - ((aEnd.Y - aStart.Y) * (aStart.X - bStart.X));

            //Lines are parallel if d == 0, so check if they're coincident
            if (d == 0.0f)
            {
                if (nX == 0.0f && nY == 0.0f)
                {
                    //Lines are coincident, now check if they overlap
                    return ((aEnd.X > bStart.X && aStart.X < bEnd.X) || (aEnd.Y > bStart.Y && aStart.Y < bEnd.Y));
                }
                else
                    return false;
            }

            float uX = nX / d;
            float uY = nY / d;

            return (uX >= 0.0f && uX <= 1.0f && uY >= 0.0f && uY <= 1.0f);
        }

        private static bool CollideRectRect(RectangleCollider a, RectangleCollider b)
	    {
		    if (a.GetBottom() < b.GetTop())
			    return false;

		    if (a.GetTop() > b.GetBottom())
			    return false;

		    if (a.GetRight() < b.GetLeft())
			    return false;

		    if (a.GetLeft() > b.GetRight())
			    return false;

		    return true;
	    }

        private static bool CollideCircCirc(CircleCollider a, CircleCollider b)
        {
            Vector2 diff = b.GetCenter() - a.GetCenter();
            return (diff.X * diff.X + diff.Y * diff.Y < Math.Pow(XP.Distance(b.GetCenter(), a.GetCenter()),2));
        }

        private static bool CollideRectCirc(RectangleCollider a, CircleCollider b)
        {
            if (a.IntersectsPoint(b.GetCenter()))
                return true;

            //Check the circle against the four edges of the rectangle
            Vector2 pA = a.GetTopLeft();
            Vector2 pB = a.GetTopRight();
            Vector2 pC = a.GetBottomRight();
            Vector2 pD = a.GetBottomLeft();
            if (b.IntersectsLine(pA, pB, 0) || b.IntersectsLine(pB, pC, 0) || b.IntersectsLine(pC, pD, 0) || b.IntersectsLine(pD, pA, 0))
                return true;

            return false;
        }

    }
}
