using System;

namespace WorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Image jack_image = new Image("ok", 1, 1);
            OrganicWaste jack = new OrganicWaste("poop", jack_image, 2, 5); 
            Console.WriteLine(jack.GetPos()[0]);
            Meat meat = new Meat("steak", jack_image, 5, 6);

        }
    }
}
