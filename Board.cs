using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WorldDev
{
    public class Board
    {
        readonly Random random = new ();
        public readonly int x_size;
        public readonly int y_size;
        public List<Entity> entities = new ();
        private int nb_organisms = 0;
        private int increment = 0;
        public Board(int x_size, int y_size)
        {
            this.x_size = x_size;
            this.y_size = y_size;
        }
        public int GetPop()
        {
            return nb_organisms;
        }
        public int GetAI()
        {
            return increment;
        }
        public bool Includes(Entity entity)
        {
            return entities.Contains(entity);
        }
        public void Kill(Entity dying_entity, string reason="", bool spawn=true)
        {
            if (GlobalVar.die_message && reason!= "")
            {
                GlobalVar.WrappedLog(reason, ConsoleColor.Red);
            }
            entities.Remove(dying_entity);
            int x = dying_entity.GetPos().Item1;
            int y = dying_entity.GetPos().Item2;
            switch (dying_entity)
            {
                case Animal:
                    Add(new Meat(), x, y);
                    nb_organisms -= 1;
                    break;
                case Plant:
                    if (spawn) {Add(new OrganicWaste(), x, y); }
                    nb_organisms -= 1;
                    break;
            }
            GlobalVar.WrappedLog(String.Format("{0} organisms left", nb_organisms), ConsoleColor.Red);

        }
        public void Add(Entity newentity, int x=-1, int y=-1)
        {
            bool isplant = typeof(Plant).IsAssignableFrom(newentity.GetType());
            bool isanimal = typeof(Animal).IsAssignableFrom(newentity.GetType());
            if(isplant || isanimal)
            {
                nb_organisms += 1;
            }
            entities.Add(newentity);
            if (x == -1)
            {
                newentity.AssignPos(random.Next(x_size), random.Next(y_size));
            }
            else
            {
                newentity.AssignPos(x, y);
            }
            newentity.SetId(increment);
            increment += 1;
        Console.WriteLine(String.Format("{0} has been spawned",newentity.GetName()));
        }
        private List<Entity> CloseAnimals(Animal animal)
        {
            List<Entity> close_entities = new();
            foreach (Entity entity in entities.ToList())
            {
                if (entity == animal)
                {
                    continue;
                }
                else
                {
                    if (animal.IsInRange(entity, animal.visionrange))
                    {
                        close_entities.Add(entity);
                        if (GlobalVar.closeto_message)
                        {
                            Console.WriteLine(String.Format("{0} IS CLOSE TO {1}", animal.GetName(), entity.GetName()));
                        }
                    }
                }
            }
            return close_entities;
        }
        public void MovementManager(Animal animal)
        {
            List<Entity> close_entities = CloseAnimals(animal);
            foreach (Entity entity in close_entities.ToList())
            {

                bool isplant = typeof(Plant).IsAssignableFrom(entity.GetType());
                bool isanimal = typeof(Animal).IsAssignableFrom(entity.GetType());
                bool ismeat = typeof(Meat).IsAssignableFrom(entity.GetType());
                bool isherbivore = typeof(Herbivore).IsAssignableFrom(animal.GetType());
                bool iscarnivore = typeof(Carnivore).IsAssignableFrom(animal.GetType());
                if (isplant && isherbivore)
                {
                    if (animal.IsInRange(entity, animal.contactrange))
                    {
                        (animal as Herbivore).Eat(entity as Plant, this);
                        return;
                    }
                    else
                    {
                        animal.MoveTo(entity);
                        return;
                    }
                }
                if (ismeat && iscarnivore)
                {
                    if (animal.IsInRange(entity, animal.contactrange))
                    {
                        (animal as Carnivore).Eat(entity as Meat, this);
                        return;
                    }
                    else
                    {
                        animal.MoveTo(entity);
                        return;
                    }
                }
                if (isanimal)
                {
                    bool Oppositgender = (entity as Animal).gender != animal.gender;
                    bool sameFamily = entity.GetType() == animal.GetType();
                    bool ispregnant = (entity as Animal).IsPregnant() || animal.IsPregnant();
                    if (Oppositgender && sameFamily && !ispregnant)
                    {
                        if (animal.IsInRange(entity, animal.contactrange))
                        {
                            animal.MakePregnant(entity as Animal);
                            return;
                        }
                        else
                        {
                            animal.MoveTo(entity);
                            return;
                        }
                    }
                    if (iscarnivore && !sameFamily)
                    {
                        if (animal.IsInRange(entity, animal.contactrange))
                        {
                            animal.Attack(entity as Animal, this);
                            return;
                        }
                        else
                        {
                            animal.MoveTo(entity);
                            return;
                        }
                    }
                    
                }
            }
            int dx = random.Next(100) <= 50 ? random.Next(GlobalVar.mouvementrange) : random.Next(GlobalVar.mouvementrange) * -1;
            int dy = random.Next(100) <= 50 ? random.Next(GlobalVar.mouvementrange) : random.Next(GlobalVar.mouvementrange) * -1;
            animal.Move(dx, dy, this);
        }
        public void Update()
        {
            foreach (Entity entity in entities.ToList())
            {
                if (typeof(OrganicWaste).IsAssignableFrom(entity.GetType())) { continue; }
                Thread.Sleep(GlobalVar.loop_cooldown);
                entity.Update(this);
            }
        }
    }
}
