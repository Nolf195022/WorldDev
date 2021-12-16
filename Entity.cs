﻿using System.Collections.Generic;

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
        public List<int> GetPos()
        {
            List<int> pos = new List<int>(2);
            pos.Add(this.x_pos);
            pos.Add(this.y_pos);
            return pos;
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
    }
}
