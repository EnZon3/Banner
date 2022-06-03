using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.util.Crash
{
    class Crash
    {
        public static void BChk(string e)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("We're sorry but your system encountered an exception");
            Console.WriteLine("If this is the first time you've seen this screen, then try to restart your computer.");
            Console.WriteLine("If this screen occurs frequently with the same error then it's probably a bug or you're doing something wrong.");
            Console.WriteLine();
            Console.WriteLine(e);
            Console.WriteLine();
            Console.WriteLine("Please restart your computer.");
            while (true)
            {

            }
        }
    }
}
