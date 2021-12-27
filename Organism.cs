using System;

namespace WorldDev
{
    public abstract class Organism : Entity
    {
        private int healt;
        private int energy;
        private int maxhealt;
        private int maxenergy;
        public Organism(string name, int maxhealt, int maxenergy):
            base(name)
        {
            this.healt = maxhealt;
            this.energy = maxenergy;
            this.maxhealt = maxhealt;
            this.maxenergy = maxenergy;
        }
        public int GetHealt()
        {
            return healt;
        }
        public void LoseHealt(int damage)
        {
            healt -= damage;
            Console.WriteLine(String.Format("{0} has {1} healt left", GetName(), healt));
        }
        public void HealtToEnergy(Board board)
        {
            const int amount = 5;
            this.healt -= amount;
            if (this.healt <= 1)
            {
                board.Kill(this, String.Format("{0} {1} died due to a lack of energy", this.GetName(), this.GetPos()));
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
        public void AddEnergy()
        {
            this.energy = this.maxenergy;
        }
    }
}