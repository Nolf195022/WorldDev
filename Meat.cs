using System;
namespace WorldDev
{
    public class Meat : Entity
    {
        public Meat() :
            base("Meat")
        {
        }
        private void ToOrganicWaste(Board board)
        {
            board.Kill(this, String.Format("Expired meat (at position {0}) is becoming organic waste.",this.GetPos()));
            board.Add(new OrganicWaste());
        }
    }
}