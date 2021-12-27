using System;

namespace WorldDev
{
    class Program
    {
        static void Main(string[] args)
        {
            Board map = new Board(1000, 1000);
            Plant rose = new Rose();
            map.Add(rose);
            for (int i = 0; i < 200; i++)
            {
                map.Update();
            }
        }
    }
}