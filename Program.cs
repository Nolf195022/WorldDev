using System;

namespace WorldDev
{
    class Program
    {
        static void Main(string[] args)
        {
            board map = new board(500, 500);
            Plant rose = new Rose();
            map.Add(rose);
            rose.GetPos().ForEach(Console.WriteLine);
            for (int i = 0; i < 200; i++)
            {
                map.Update();
            }
        }
    }
}