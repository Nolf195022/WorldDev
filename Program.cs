using System;

namespace WorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OrganicWaste jack = new OrganicWaste("poop", 2, 5); 
            Console.WriteLine(jack.GetPos()[0]);
            Meat meat = new Meat("steak", 5, 6);

        }
    }
}
