using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using xnapunk.colliders;
using xnapunk.task;
using xnapunk.graphics;

namespace xnapunk
{
    public class World
    {

        private List<Entity> Entities = new List<Entity>();
        public List<Task> Tasks = new List<Task>();

        public World()
        {

        }

        public void Add(Entity e) { Entities.Add(e); }
        public void Remove(Entity e) { Entities.Remove(e); }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = Entities.Count - 1; i >= 0; i--) Entities[i].Update(gameTime);

            for (int t = Tasks.Count - 1; t >= 0; t--)
            {
                Task task = Tasks[t];
                task.tick();
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            Sort();
            for (int i = 0; i < Entities.Count; i++) Entities[i].Draw(gameTime);
        }

        protected void Sort()
        {
            InsertionSort(Entities, Entity.Compare);
        }

        public static void InsertionSort<T>(IList<T> list, Comparison<T> comparison)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (comparison == null)
                throw new ArgumentNullException("comparison");

            int count = list.Count;
            for (int j = 1; j < count; j++)
            {
                T key = list[j];

                int i = j - 1;
                for (; i >= 0 && comparison(list[i], key) > 0; i--)
                {
                    list[i + 1] = list[i];
                }
                list[i + 1] = key;
            }
        }

        public Entity Collide(Entity entity, Vector2 position, String tag)
        {
            if (entity != null && entity.Collider != null && !entity.Collider.CanCollide) return null;

            foreach (Entity e in Entities)
            {
                if (e.CollisionTags.Contains(tag))
                {
                    if (e.Collider.CanCollide &&  Collider.Collide(e.Collider, entity.Collider))
                        return e;
                }
            }
            return null;
        }

        public Entity AddGraphic(Graphic g, int x, int y)
        {
            Entity e = new Entity(new Vector2(x, y), g);
            Add(e);
            return e;
        }
        public Entity AddGraphic(Graphic g) { return AddGraphic(g, 0, 0); }

        public int EntityCount { get { return Entities.Count; } }

    }
}
