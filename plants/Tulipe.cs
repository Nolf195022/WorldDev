namespace WorldDev
{
    public class Tulipe : Plant
    {
        public Tulipe() :
            base("Tulipe", 30, 80, 15, 20)
        {
        }
        public override void Extend(Board board)
        {
            board.Add(new Tulipe());
        }
    }
}