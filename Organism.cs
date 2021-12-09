using System;

namespace WorldApp
{
    public abstract class Organism : Entity
    {
        private int healt;
        private int energy;
        public Organism(string name, int maxhealt, int maxenergy):
            base(name)
        {
            this.healt = maxhealt;
            this.energy = maxenergy;
        }
        public void HealtToEnergy(Board board)
        {
            const int amount = 5;
            this.healt -= amount;
            if (this.healt <= 1)
            {
                board.Kill(this, "energy");
                return;
            }
            this.energy += amount;
            Console.WriteLine(String.Format("{0} has converted {1} health ({2} left) into {1} energy", this.GetName(), amount, this.healt));
        }
        public void LoseEnergy(Board board)
        {
            this.energy -= 1; 
            if (this.energy == 0)
            {
                this.HealtToEnergy(board);
            }
        }
    }
}