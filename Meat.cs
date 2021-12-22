namespace WorldDev
{
    class Meat : Entity
    {
        public Meat(string name) :
            base("Meat")
        {
        }
        private void ToOrganicWaste()
        {
            Board.Kill(this, "waste");
            entities.Add(OrganicWaste);
            Console.WriteLine(String.Format("{0} is converted into OrganicWaste", this.GetName()));
            
        }
    }
    }
}
