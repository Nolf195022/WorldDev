using System;
using System.Collections.Generic;
using System.Threading;

namespace WorldDev
{
    class Program
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
            for (int i = 0; i < GlobalVar.start_entity_count; i++)
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
            int timeunit = 0;
            while(map.GetPop()>0 && timeunit < GlobalVar.infiniteloop_prevent)
            {
                timeunit += 1;
                map.Update();
            }
            if(timeunit == GlobalVar.infiniteloop_prevent)
            {
                GlobalVar.WrappedLog(new string('-', 40), ConsoleColor.Red);
                GlobalVar.WrappedLog("Life is enduring and could prosper forever", ConsoleColor.Red);
                GlobalVar.WrappedLog(String.Format("{1} organisms have lived on this world ", timeunit, map.GetAI()), ConsoleColor.Red);
                GlobalVar.WrappedLog(new string('-', 40), ConsoleColor.Red);
            }
            else
            {
                GlobalVar.WrappedLog(new string('-', 40), ConsoleColor.Red);
                GlobalVar.WrappedLog("There are no more life forms in this world", ConsoleColor.Red);
                GlobalVar.WrappedLog(String.Format("Life lasted for {0} timeunits and {1} organisms have lived on this world ", timeunit, map.GetAI()), ConsoleColor.Red);
                GlobalVar.WrappedLog(new string('-', 40), ConsoleColor.Red);
            }
        }
    }
}