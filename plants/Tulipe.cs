namespace WorldDev
{
    public class Tulipe : Plant
    {
        public Tulipe() :
            base("Tulipe", 30, 40, 15, 20)
        {
        }
        public void Extend(Board board)
        {
            board.Add(new Tulipe());
        }
    }
}