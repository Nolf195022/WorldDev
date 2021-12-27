using System.Collections.Generic;

namespace WorldDev
{
    public abstract class Entity
    {
        private string name;
        private int x_pos;
        private int y_pos;
        public Entity(string name)
        {
            this.name = name;
        }
        public (int,int) GetPos()
        {
            return (this.x_pos,this.y_pos);
        }
        public string GetName()
        {
            return this.name;
        }
        public void Move(int dx, int dy)
        {
            this.x_pos += dx;
            this.y_pos += dy;
        }
        public void AssignPos(int x, int y)
        {
            this.x_pos = x;
            this.y_pos = y;
        }
        public bool IsInRange(int x, int y, int range)
        {
            int xmin = this.x_pos - range;
            int xmax = this.x_pos + range;
            int ymin = this.y_pos - range;
            int ymax = this.y_pos + range;
            if ((x > xmin) && (x < xmax) && (y > ymin) && (y < ymax)){
                return true;
            }
            return false;
        }
    }
}
