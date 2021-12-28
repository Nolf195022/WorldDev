using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDev
{
    public class GlobalVar
    {
        public const int mouvementrange = 10;
        public const int start_entity_count = 40;
        public const int loop_cooldown = 20;
        public const bool energy_conversion_message = false;
        public const bool made_pregnant_message = true;
        public const bool die_message = true;
        public const bool closeto_message = false;
        public const bool approaching_message = false;
        public static void WrappedLog(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
