using System;

namespace WorldDev
{
    public abstract class Organism : Entity
    {
        protected int healt;
        protected int energy;
        public readonly int maxhealt;
        public readonly int maxenergy;
        public Organism(string name, int maxhealt, int maxenergy):
            base(name)
        {
            this.healt = maxhealt;
            this.energy = maxenergy;
            this.maxhealt = maxhealt;
            this.maxenergy = maxenergy;
        }
        public override void Update(Board board)
        {
            LoseEnergy(board);
        }
        public int GetHealt()
        {
            return healt;
        }
        public void LoseHealt(int damage)
        {
            healt -= damage;
        }
        public void HealtToEnergy(Board board)
        {
            const int amount = 5;
            this.healt -= amount;
            if (this.healt <= 1)
            {
                board.Kill(this, String.Format("{0} died due to a lack of energy", this.GetName()));
                return;
            }
            this.energy += amount;
            if (energy_conversion_message)
            {
                Console.WriteLine(String.Format("{0} has converted {1} health ({2} left) into {1} energy",GetName(), amount, healt));
            }
        }
        public void LoseEnergy(Board board)
        {
            this.energy -= 1; 
            if (this.energy == 0)
            {
                this.HealtToEnergy(board);
            }
        }
        public void AddEnergy()
        {
            this.energy = this.maxenergy;
        }
    }
}