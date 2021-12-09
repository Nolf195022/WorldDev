namespace WorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board map = new Board(100, 200);
            Plant rose = new Rose();
            map.Add(rose);
            for (int i = 0; i < 200; i++)
            {
                map.Update();
            }
        }
    }
}