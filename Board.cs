using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    public class Board
    {
        public Image image;
        public int x_size;
        public int y_size;
        public List<Entity> entities;
        public Board(Image image, int x_size, int y_size)
        {

            this.image = image;
            this.x_size = x_size;
            this.y_size = y_size;
        }

        public int get_size()
        {
            return 1;
        }
        public void kill(Entity e)
        {

        }
        public void add(Entity e)
        {

        }
        public void display(Entity e)
        {

        }

    }
}
