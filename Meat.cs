using System;
namespace WorldDev
{
    public class Meat : Entity
    {
        private int lifetime = 0;
        public Meat() :
            base("Meat")
        {
        }
        private void ToOrganicWaste(Board board)
        {
            board.Kill(this, String.Format("Expired {0} is becoming organic waste.",this.GetName()));
            board.Add(new OrganicWaste(), this.x_pos, this.y_pos);
        }
        public override void Update(Board board)
        {
            lifetime += 1;
            if (lifetime == 15)
            {
                ToOrganicWaste(board);
            }
        }
    }
}