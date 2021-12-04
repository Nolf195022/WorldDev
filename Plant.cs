using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    class Plant : Organism
    {
        private int rootrange;
        private int extendrange;
        public Plant(string name, Image image, int x, int y, int maxhealt, int maxenergy, int rootrange, int extendrange):
            base(name, image, x, y, maxhealt, maxenergy)
        {
            this.rootrange = rootrange;
            this.extendrange = extendrange;
        }
        public void Eat(OrganicWaste organicWaste)
        {

        }
        public void Extend()
        {

        }
    }
}
