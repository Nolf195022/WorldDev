using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    public abstract class Entity
    {
        private string name;
        private int x_pos;
        private int y_pos;
        public Entity(string name, int x, int y)
        {
            this.name = name;
            this.x_pos = x;
            this.y_pos = y;
        }
        public List<int> GetPos()
        {
            List<int> pos = new List<int>(2);
            pos.Add(this.x_pos);
            pos.Add(this.y_pos);
            return pos;
        }
    }
}
