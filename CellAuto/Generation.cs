using System;
using System.Text;
using System.Threading.Tasks;

namespace CellAuto
{
    class Generation
    {
        private const int SIZE_GENERATION = 20;
        private Cells[] generations;
        private Int32 seed;

        /* Generation Constructor
         * -----------------------
         * This will firstly generate the first
         * generation based on the given seed.
         * It will then go through generations 1-19
         * and set those cells based on the previous set of cells generated from
         * the for loop. It will initialise those cells based on the previous cells
         * */
        public Generation(Int32 seed)
        {
            this.seed = seed;
            generations = new Cells[SIZE_GENERATION];
            for (int i = 0; i < SIZE_GENERATION; i++)
            {
                if (i == 0)
                {
                    generations[i] = new Cells(seed);
                }
                else
                {
                    generations[i] = new Cells();
                    generations[i].setCells(generations[i - 1].getCells);
                }
            }
        }

        public void printCells()
        {
            for (int i = 0; i < SIZE_GENERATION; i++)
            {
                if(i < 9)
                {
                    Console.Out.Write("gen   {0} ", i + 1);
                }
                else
                {
                    Console.Out.Write("gen  {0} ", i + 1);
                }
                generations[i].printCells();
            }
        }

        public Cells[] getGenerations
        {
            get { return generations; }
        }


        /* Method: getHash
         * -----------------------
         * This will firstly retrieve the final line's group of cells
         *  and then loop through each element within that array to calculate
         *  the hash value given by the states.
         * */


        public int getHash()
        {
            int hashValue = 0;
            Cell[] finalLine = generations[SIZE_GENERATION - 1].getCells;
            for (int i = 0; i < finalLine.Length; i++)
            {
                hashValue += (i + 1) * (int)finalLine[i].getCurrentState;
            }
            return hashValue;
        }

    }
}
