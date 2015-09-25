using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 seed;
            if (!parseArgs(args, out seed))
            {
                Console.WriteLine("Syntax: CellAutomata seed");
                Console.WriteLine("Seed must be a positive integer");
            }
            else
            {
                Generation generation = new Generation(seed);
                generation.printCells();
                Console.WriteLine("The final hash = {0} ", generation.getHash());
            }
        }

        static bool parseArgs(string[] args, out Int32 number)
        {
            number = 0;
            if (args.Length != 1) return false;

            return (Int32.TryParse(args[0], out number) && number > 0);
        }


    }
}
