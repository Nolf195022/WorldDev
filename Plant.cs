using System;

namespace WorldDev
{
    public abstract class Plant : Organism
    {
        private int rootrange;
        private int extendrange;
        public Plant(string name, int maxhealt, int maxenergy, int rootrange, int extendrange) :
            base(name, maxhealt, maxenergy)
        {
            this.rootrange = rootrange;
            this.extendrange = extendrange;
        }

        public void Eat(OrganicWaste organicwaste, Board board)
        {
            board.Kill(organicwaste, String.Format("{0} has been eaten by {1}", organicwaste.GetName(), this.GetName()));
            this.AddEnergy();
        }
    }
}
