using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDev
{
    public class Lion : Carnivore
    {
        public Lion(int pregnancycd = 0) :
            base("Lion", 300 ,80,50,5,100, pregnancycd)
        {
        }
        public override void Reproduce(Board board)
        {
            board.Add(new Lion(1000), x_pos, y_pos);
        }
    }
}
