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
        public void Eat(OrganicWaste organicwaste, board board)
        {
            board.Kill(organicwaste, "eat");
            this.AddEnergy();
        }
        public void Extend()
        {

        }
    }
}
