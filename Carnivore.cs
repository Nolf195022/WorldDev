﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    class Carnivore : Animal
    {
        public Carnivore(string name, int x, int y, int maxhealt, int maxenergy, int visionrange, int contactrange):
            base(name, x, y, maxhealt, maxenergy, visionrange, contactrange)
        {
        }
        public void Eat(Meat meat)
        {

        }
    }
}
