namespace WorldDev
{
    public class Rose : Plant
    {
        public Rose() :
            base("Rose", 20, 40, 15, 20)
        {
        }
        public void Extend(Board board)
        {
            board.Add(new Rose());
        }
    }
}
