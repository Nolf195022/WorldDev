using System.Collections.Generic;
using System;

namespace WorldDev
{
    public abstract class Entity
    {
        public readonly string name;
        protected int x_pos;
        protected int y_pos;
        protected int id;
        public Entity(string name)
        {
            this.name = name;
            
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public (int,int) GetPos()
        {
            return (this.x_pos,this.y_pos);
        }
        public virtual string GetName()
        {
            return String.Format("{0}, id : {3},  ({1},{2})", name, x_pos, y_pos, id);
        }
        public void AssignPos(int x, int y)
        {
            this.x_pos = x;
            this.y_pos = y;
        }
        public bool IsInRange(Entity entity, int range)
        {
            int x = entity.x_pos;
            int y = entity.y_pos;
            int xmin = this.x_pos - range;
            int xmax = this.x_pos + range;
            int ymin = this.y_pos - range;
            int ymax = this.y_pos + range;
            if ((x > xmin) && (x < xmax) && (y > ymin) && (y < ymax)){
                return true;
            }
            return false;
        }

        public abstract void Update(Board board);
    }
}
