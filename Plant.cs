﻿using System;

namespace WorldDev
{
    public abstract class Plant : Organism
    {
        public readonly int rootrange;
        public readonly int extendrange;
        protected int lifetime = 0 ;
        public Plant(string name, int maxhealt, int maxenergy, int rootrange, int extendrange) :
            base(name, maxhealt, maxenergy)
        {
            this.rootrange = rootrange;
            this.extendrange = extendrange;
        }
        public override string GetName()
        {
            return String.Format("{0}, id : {3}, ({1},{2}), hp :{4}, energie {5} ", name, x_pos, y_pos, id, healt, energy);
        }
        public void Eat(OrganicWaste organicwaste, Board board)
        {
            board.Kill(organicwaste, String.Format("{0} has been eaten by {1}", organicwaste.GetName(), GetName()));
            this.AddEnergy();
        }
        public abstract void Extend(Board board);
        public override void Update(Board board)
        {
            base.Update(board);
            if (board.Includes(this))
            {
                if (lifetime % 1000 == 400)
                {
                    Random generator = new();
                    bool doreprod= generator.Next(100) <= 20;
                    if (doreprod)
                    {
                        this.Extend(board);
                    }
                }
                lifetime += 1;
            }
        }
    }
}