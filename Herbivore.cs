namespace WorldDev
{
    class Herbivore : Animal
    {
        public Herbivore(string name, int maxhealt, int maxenergy, int visionrange, int contactrange) :
            base(name, maxhealt, maxenergy, visionrange, contactrange)
        {
        }
        public void Eat(Plant plant)
        {

        }
    }
}
