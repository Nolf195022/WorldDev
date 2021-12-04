using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldApp
{
    public class Image
    {
        public string href;
        public int x_size;
        public int y_size;


        public Image(string href, int x_size, int y_size)
        {

            this.href = href;
            this.x_size = x_size;
            this.y_size = y_size;

        }

        public void Scale()
        {

        }
    }
}
