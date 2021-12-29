using System;
using System.Threading;

namespace WorldDev
{
    public abstract class Animal : Organism
    {
        public readonly int visionrange;
        public readonly int contactrange;
        public readonly int attack_damage;
        public readonly string gender;
        protected bool ispregnant = false;
        protected int pregnancyprogress = 0;
        public int pregnancycooldown = 0;
        public Animal(string name, int maxhealt, int maxenergy, int visionrange, int contactrange, int attack_damage, int pregancycd=0) :
            base(name, maxhealt, maxenergy)
        {
            this.visionrange = visionrange;
            this.contactrange = contactrange;
            this.attack_damage = attack_damage;
            Random generator = new ();
            gender = generator.Next(100) <= 50 ? "Male" : "Female";
            pregnancycooldown = pregancycd;
        }
        public abstract void Reproduce(Board board);

        public override string GetName()
        {
            return String.Format("{0}, id : {4}, {3}, ({1},{2}), hp :{5}, energie {6} ",name, x_pos, y_pos, gender, id, healt, energy);
        }
        public bool IsPregnant()
        {
            return ispregnant;
        }
        public void MakePregnant(Animal animal)
        {
            if (pregnancycooldown > 0) { return; }
            Animal male = this;
            Animal female = animal;
            if (gender == "Female") { 
                ispregnant = true;
                female = this;
                male = animal;
            }
            else 
            { 
                animal.ispregnant = true;
            }
            if (made_pregnant_message)
            {
               WrappedLog(String.Format("[{0}] made [{1}] pregnant ", male.GetName(), female.GetName()),ConsoleColor.Blue);
            }
        }
        public override void Update(Board board)
        {
            base.Update(board);
            if(board.Includes(this))
            {
                if (ispregnant)
                {
                    if (pregnancyprogress == 70)
                    {
                        ispregnant = false;
                        pregnancyprogress = 0;
                        pregnancycooldown = 1000;
                        Random generator = new();
                        bool doreprod = generator.Next(100) <= 60;
                        if (doreprod)
                        {
                            Reproduce(board);
                            WrappedLog(String.Format("{0} gave birth", GetName()), ConsoleColor.Green);
                        }
                        else
                        {
                            WrappedLog(String.Format("{0} lost her baby", GetName()), ConsoleColor.Yellow);
                        }
                    }
                    else { pregnancyprogress += 1; }
                }
                pregnancycooldown -= 1;
                board.MovementManager(this);
            }   
        }
        public void Attack(Animal animal, Board board)
        {
            animal.LoseHealt(attack_damage);
            if (animal.healt <= 0)
            {
                WrappedLog(String.Format("{0} killed {1}", GetName(), animal.GetName()), ConsoleColor.Yellow);

                board.Kill(animal);
                return;
            }
            else
            {
                WrappedLog(String.Format("{0} attacked {1} and inflicted {2} damage ({3} health left)", GetName(), animal.GetName(), attack_damage, animal.healt), ConsoleColor.Yellow);
                //counter-attack
                animal.Attack(this, board);
            }
        }
        public void Move(int x, int y, Board board)
        {
            int xmax = board.x_size;
            int ymax = board.y_size;
            int oldx = x_pos;
            int oldy = y_pos;
            int newx = x + oldx;
            int newy = y + oldy;
            if(newx > xmax) { newx = xmax; }
            if (newx < 0) { newx = 0; }
            if (newy > ymax) { newy = ymax; }
            if (newy < 0) { newy = 0; }
            AssignPos(newx, newy);
            //Console.WriteLine(String.Format("{0} moved from ({1},{2})", GetName(), oldx, oldy));
        }
        private static int SetDirection(int actual, int target)
        {
            if (actual > target)
            {
                if(actual - mouvementrange < target) { return target;}
                return actual - mouvementrange;
            }
            if (actual < target)
            {
                if (actual + mouvementrange > target) { return target; }
                return actual + mouvementrange;
            }
            return actual;
        }
        public void MoveTo(Entity entity)
        {
            int x = entity.GetPos().Item1;
            int y = entity.GetPos().Item2;        
            AssignPos(SetDirection(x_pos, x), SetDirection(y_pos, y));
            if (approaching_message)
            {
                Console.WriteLine(String.Format("{0} is approaching {1}", GetName(), entity.GetName()));
            }
        }
    }
}
