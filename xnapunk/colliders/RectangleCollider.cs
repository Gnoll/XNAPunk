using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace xnapunk.colliders
{
    public class RectangleCollider : Collider
    {

        public Vector2 Size;

        public RectangleCollider(Vector2 size, Vector2 offset)
            : base(offset)
        {
            Size = size;
        }

        public override ColliderType Type() { return ColliderType.Rectangle; }

        public override bool IntersectsPoint(Vector2 point)
        {
            return (point.X > GetLeft() && point.Y > GetTop() && point.X < GetRight() && point.Y < GetBottom());
        }

        public override bool IntersectsLine(Vector2 start, Vector2 end, float lineWidth)
        {
            if (IntersectsPoint(start) || IntersectsPoint(end)) return true;

            Vector2 tL = GetTopLeft();
            Vector2 tR = GetTopRight();
            Vector2 bL = GetBottomLeft();
            Vector2 bR = GetBottomRight();

            return Collider.LinesIntersect(start, end, tL, tR) || Collider.LinesIntersect(start, end, tR, bR) || Collider.LinesIntersect(start, end, bL, bR) || Collider.LinesIntersect(start, end, bL, tL);

        }

        public float GetLeft()
        {
            return (float)(Entity.Position.X + Offset.X);
        }

        public float GetRight()
        {
            return (float)(Entity.Position.X + Offset.X + Size.X);
        }

        public float GetTop()
        {
            return (float)(Entity.Position.Y + Offset.Y);
        }

        public float GetBottom()
        {
            return (float)(Entity.Position.Y + Offset.Y + Size.Y);
        }

        public Vector2 GetTopLeft() { return new Vector2(GetLeft(), GetTop()); }
        public Vector2 GetTopRight() { return new Vector2(GetRight(), GetTop()); }
        public Vector2 GetBottomLeft() { return new Vector2(GetLeft(), GetBottom()); }
        public Vector2 GetBottomRight() { return new Vector2(GetRight(), GetBottom()); }

    }
}
