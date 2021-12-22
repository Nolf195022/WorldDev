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
            Add(animal);
        }
        public void Attack(Animal animal)
        {
            if (visionrange == contactrange)
            {
                Board.Kill(animal, "attack");
                Console.WriteLine(String.Format("{0} attacked {1}", this.GetName, animal.GetName()));
            }
        }
        public void Move(Animal animal)
        {
            this.Move(Random.Next(10), Random.Next(10));
        }
    }
}
