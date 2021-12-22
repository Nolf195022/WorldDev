using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldDev
{
    public class board
    {
        Random random = new Random();
        public int x_size;
        public int y_size;
        public List<Entity> entities = new List<Entity>();
        public board(int x_size, int y_size)
        {
            this.x_size = x_size;
            this.y_size = y_size;
        }
        public void Kill(Entity e, string reason="")
        {
            if (reason == "")
            {
                Console.WriteLine(String.Format("{0} died", e.GetName()));
            }
            else if(reason == "eaten")
            {
                Console.WriteLine(String.Format("{0} has been eaten by {1}", e.GetName(), reason));
            }
            else
            {
                Console.WriteLine(String.Format("{0} died due to {1}", e.GetName(), reason));
            }
            entities.Remove(e);
        }
        public void Add(Entity e)
        {
            entities.Add(e);
            e.AssignPos(random.Next(x_size),random.Next(y_size));
        }
        public void Update()
        {
            foreach (Organism o in entities.ToList())
            {
                o.LoseEnergy(this);
            }
        }
    }
}
