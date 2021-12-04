using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    class Animal : Organism
    {
        private int visionrange;
        private int contactrange;
        private bool femalegender;
        public Animal(string name, Image image, int x, int y, int maxhealt, int maxenergy, int visionrange, int contactrange):
            base(name, image, x, y, maxhealt, maxenergy)
        {
            this.visionrange = visionrange;
            this.contactrange = contactrange;
            this.femalegender = true; //add random boolean.
        }
        public void Reproduce(Animal animal)
        {

        }
        public void Attack(Animal animal)
        {

        }
        public void Move(Animal animal)
        {

        }
    }
}
