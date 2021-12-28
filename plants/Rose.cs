namespace WorldDev
{
    public class Rose : Plant
    {
        public Rose() :
            base("Rose", 20, 80, 15, 20)
        {
        }
        public override void Extend(Board board)
        {
            board.Add(new Rose());
        }
    }
}
