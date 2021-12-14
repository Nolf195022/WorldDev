namespace WorldDev
{
    public abstract class Animal : Organism
    {
        private int visionrange;
        private int contactrange;
        private bool femalegender;
        public Animal(string name, int maxhealt, int maxenergy, int visionrange, int contactrange) :
            base(name, maxhealt, maxenergy)
        {
            this.visionrange = visionrange;
            this.contactrange = contactrange;
            this.femalegender = true; //add random boolean.
        }
        public void Reproduce(Animal animal)
        {

        }
        public void Attack(Animal animal)
        {

        }
        public void Move(Animal animal)
        {

        }
    }
}
