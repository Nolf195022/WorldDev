using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDev
{
    public class Giraffe : Herbivore
    {
        public Giraffe(int pregnancycd=0) :
            base("Giraffe", 400, 50, 30, 10, 80, pregnancycd)
        {
        }
        public override void Reproduce(Board board)
        {
            board.Add(new Giraffe(1000), x_pos, y_pos);
        }
    }
}
