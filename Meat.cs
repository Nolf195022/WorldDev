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
            board.Kill(this, "waste");
            Add(OrganicWaste);
            Console.WriteLine(String.Format("{0} is converted into OrganicWaste", this.GetName()));
            
        }
    }
    }
}
