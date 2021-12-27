using System;

namespace WorldDev
{
    public abstract class Animal : Organism
    {
        private int visionrange;
        private int contactrange;
        private int attack_damage;
        private bool femalegender;
        public Animal(string name, int maxhealt, int maxenergy, int visionrange, int contactrange, int attack_damage) :
            base(name, maxhealt, maxenergy)
        {
            this.visionrange = visionrange;
            this.contactrange = contactrange;
            this.attack_damage = attack_damage;
            Random generator = new Random();
            femalegender = generator.Next(100) <= 50 ? true : false; //add random boolean.
        }
        public void Reproduce(Animal animal)
        {
            //ajouter un bébé à la mère apès une periode de gestation
        }
        public void Attack(Animal animal, Board board)
        {
            Console.WriteLine(String.Format("{0} attacked {1} and inflicted {2} damage", this.GetName(), animal.GetName(),this.attack_damage));
            if(animal.GetHealt()-this.attack_damage <= 0)
            {
                board.Kill(animal);
                Console.WriteLine(String.Format("{1} killed {0}", this.GetName(), animal.GetName(), this.attack_damage));
                return;
            }
            else
            {
                animal.LoseHealt(this.attack_damage);
            }
        }
        public void Move(int x, int y, Board board)
        {
            int xmax = board.getSize().Item1;
            int ymax = board.getSize().Item2;
            int newx = x + this.GetPos().Item1;
            int newy = y + this.GetPos().Item2;
            int oldx = this.GetPos().Item1;
            int oldy = this.GetPos().Item2;
            if (newx <= xmax)
            {
                this.AssignPos(newx, oldy);
            }
            else { this.AssignPos(xmax, oldy);}
            if (newy <= ymax)
            {
                this.AssignPos(oldx, newy);
            }
            else { this.AssignPos(oldx, ymax); }
            Console.WriteLine(String.Format("{0} moved to {1}", GetName(), GetPos()));
        }
    }
}
