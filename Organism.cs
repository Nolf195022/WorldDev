using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    abstract class Organism : Entity
    {
        private int healt;
        private int energy;
        public Organism(string name, Image image, int x, int y, int maxhealt, int maxenergy):
            base(name, image, x, y)
        {
            this.healt = maxhealt;
            this.energy = maxenergy;
        }
        public void HealtToEnergy()
        {

        }
        public void LoseEnergy()
        {

        }
    }
}
