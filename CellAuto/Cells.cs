using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAuto
{

    class Cells
    {
        private const int SIZE = 64;
        private Cell[] cells, previousCells;
        public Cells()
        {
            cells = new Cell[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                cells[i] = new Cell();
                cells[i].setPotentialStates();
            }
        }

        public Cells(Int32 seed)
        {
            cells = new Cell[SIZE];
            Random r = new Random(seed);
            for (int i = 0; i < SIZE; i++)
            {
                cells[i] = new Cell();
                int randomNumber = r.Next(0, Enum.GetNames(typeof(State)).Length);
                cells[i].setStateRandomly(randomNumber);
                cells[i].setPotentialStates();

            }
        }

        public void setCells(Cell[] previousCells)
        {
            this.previousCells = previousCells;
            for (int i = 0; i < SIZE; i++)
            {
                State[] neighbourStates = getNeighbourStates(i);
                cells[i].setState(getTargetedState(neighbourStates, previousCells[i]));
                cells[i].setPotentialStates();
            }
        }

        private State[] getNeighbourStates(int position)
        {
            State[] neighbourStates = new State[4];
            if (position == 0)
            {
                neighbourStates[0] = previousCells[SIZE - 1].getCurrentState;
                neighbourStates[1] = previousCells[position].getCurrentState;
                neighbourStates[2] = previousCells[position].getNextState;
                neighbourStates[3] = previousCells[position + 1].getCurrentState;
            }
            else if (position == SIZE - 1)
            {
                neighbourStates[0] = previousCells[SIZE - 2].getCurrentState;
                neighbourStates[1] = previousCells[position].getCurrentState;
                neighbourStates[2] = previousCells[position].getNextState;
                neighbourStates[3] = previousCells[0].getCurrentState;
            }
            else
            {
                neighbourStates[0] = previousCells[position - 1].getCurrentState;
                neighbourStates[1] = previousCells[position].getCurrentState;
                neighbourStates[2] = previousCells[position].getNextState;
                neighbourStates[3] = previousCells[position + 1].getCurrentState;
            }
            return neighbourStates;
        }

        private State getTargetedState(State[] neighbourStates, Cell cell)
        {
            State targetedState, leftState, rightState;
            leftState = neighbourStates[0];
            rightState = neighbourStates[3];
            targetedState = cell.getCurrentState;
            if (cell.getNextState == leftState && cell.getNextState == rightState)
            {
                targetedState = cell.getPreviousState;
            }
            else if (cell.getNextState == leftState || cell.getNextState == rightState)
            {
                targetedState = cell.getNextState;
            }
            else if (cell.getCurrentState == leftState && cell.getCurrentState == rightState)
            {
                targetedState = cell.getNextState;
            }
            return targetedState;
        }


        public Cell[] getCells
        {
            get { return cells; }
        }

        public void printCells()
        {
            for (int i = 0; i < SIZE; i++)
            {
                Console.Out.Write(cells[i].getState());
            }
            Console.WriteLine();
        }


    }
}
