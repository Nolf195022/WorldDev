using System;

namespace WorldDev
{
    public abstract class Plant : Organism
    {
        public readonly int rootrange;
        public readonly int extendrange;
        protected int reprod_delay;
        public Plant(string name, int maxhealt, int maxenergy, int rootrange, int extendrange, int reprod_delay) :
            base(name, maxhealt, maxenergy)
        {
            this.rootrange = rootrange;
            this.extendrange = extendrange;
            this.reprod_delay = reprod_delay;
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
                lifetime += 1;
                if (lifetime % reprod_delay == 0)
                {
                    Random generator = new();
                    bool doreprod = generator.Next(100) <= 50;
                    if (doreprod)
                    {
                        WrappedLog(String.Format("{0} has extended ", GetName()), ConsoleColor.Green);
                        Extend(board);
                    }
                }
                
            }
        }
    }
}