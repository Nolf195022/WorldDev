using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldDev
{
    public class Board
    {
        Random random = new Random();
        private int x_size;
        private int y_size;
        public List<Entity> entities = new List<Entity>();
        public Board(int x_size, int y_size)
        {
            this.x_size = x_size;
            this.y_size = y_size;
        }
        public (int, int) getSize()
        {
            return (x_size, y_size);
        }
        public void Kill(Entity dying_entity, string reason="")
        {
            Console.WriteLine(reason);
            entities.Remove(dying_entity);
            switch (dying_entity)
            {
                case Animal animal:
                    Add(new Meat(), dying_entity.GetPos().Item1, dying_entity.GetPos().Item2);
                    break;
                case Plant plant:
                    Add(new OrganicWaste(), dying_entity.GetPos().Item1, dying_entity.GetPos().Item2);
                    break;
            }
        }
        public void Add(Entity newentity, int x=-1, int y=-1)
        {
            entities.Add(newentity);
            if (x == -1)
            {
                newentity.AssignPos(random.Next(x_size), random.Next(y_size));
            }
            else
            {
                newentity.AssignPos(x, y);
            }
            Console.WriteLine(String.Format("{0} has been spawned at {1}",newentity.GetName(),newentity.GetPos()));
        }
        public void Update()
        {
            foreach (Entity entity in entities.ToList())
            {
                switch (entity)
                {
                    case Organism organism:
                        organism.LoseEnergy(this);
                        switch (organism)
                        {
                            case Animal animal:
                                animal.Move(random.Next(5), random.Next(5), this);
                                break;
                            case Plant plant:
                                break;
                        }
                        break;
                }
            }
        }
    }
}
