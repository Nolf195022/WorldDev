using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDev
{
    public abstract class Carnivore : Animal
    {
        public Carnivore(string name, int maxhealt, int maxenergy, int visionrange, int contactrange, int attack_damage) :
            base(name, maxhealt, maxenergy, visionrange, contactrange, attack_damage)
        {
        }
        public void Eat(Meat meat, Board board)
        {
            board.Kill(meat, String.Format("{0} has been eaten by {1}", meat.GetName(),  this.GetName()));
            this.AddEnergy();
        }
    }
}
