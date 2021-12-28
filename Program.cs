using System;
using System.Collections.Generic;
using System.Threading;

namespace WorldDev
{
    class Program : GlobalVar
    {
        static void Main()
        {
            Board map = new (100, 100);
            List<string> entities = new ();
            entities.Add("Tulipe");
            entities.Add("Acacia");
            entities.Add("Rose");
            entities.Add("Lion");
            entities.Add("Giraffe");
            for (int i = 0; i < start_entity_count; i++)
            {
                Random generator = new();
                switch (generator.Next(entities.Count))
                {
                    case 0:
                        map.Add(new Rose());
                        break;
                    case 1:
                        map.Add(new Acacia());
                        break;
                    case 2:
                        map.Add(new Tulipe());
                        break;
                    case 3:
                        map.Add(new Lion());
                        break;
                    case 4:
                        map.Add(new Giraffe());
                        break;
                }
            }
            while(map.GetPop()>0)
            {
                map.Update();
            }
        }
    }
}