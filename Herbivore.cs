using System;
namespace WorldDev
{
    public abstract class Herbivore : Animal
    {
        public Herbivore(string name, int maxhealt, int maxenergy, int visionrange, int contactrange, int attack_damage) :
            base(name, maxhealt, maxenergy, visionrange, contactrange, attack_damage)
        {
        }
        public void Eat(Plant plant, Board board) 
        {
            board.Kill(plant , String.Format("{0} has been eaten by {1}", plant.GetName(), this.GetName()));
            this.AddEnergy();
        }
    }
}
