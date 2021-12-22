using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDev
{
    class Carnivore : Animal
    {
        public Carnivore(string name, int maxhealt, int maxenergy, int visionrange, int contactrange):
            base(name, maxhealt, maxenergy, visionrange, contactrange)
        {
        }
        public void Eat(Meat meat)
        {
            Board.Kill(meat, "eaten");
            this.AddEnergy();
        }
    }
}
