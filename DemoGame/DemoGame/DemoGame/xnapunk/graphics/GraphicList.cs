using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace xnapunk.graphics
{
    public class GraphicList : Graphic
    {

        private List<Graphic> Graphics = new List<Graphic>();


        public GraphicList(params Graphic[] graphics)
        {
            foreach (Graphic graphic in graphics) Add(graphic);
        }

        public void Add(Graphic graphic) { Graphics.Add(graphic); }
        public void Remove(Graphic graphic) { Graphics.Remove(graphic); }
        public Graphic Get(int index) { return Graphics[index]; }

        public override void Draw(Vector2 position)
        {
            foreach (Graphic graphic in Graphics) graphic.Draw(position);
        }

    }
}
