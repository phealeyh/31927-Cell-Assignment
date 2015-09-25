using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAuto
{
    enum State
    {
        SPACE,
        DOT,
        PLUS,
        HASH
    };

    class Cell
    {
        private State previousState, currentState, nextState;
        public Cell()
        {
            currentState = new State();
            previousState = new State();
            nextState = new State();
        }


        public String getState()
        {
            switch ((int)currentState)
            {
                case 0:
                    return " ";
                case 1:
                    return ".";
                case 2:
                    return "+";
                case 3:
                    return "#";
                default:
                    return "Unspecified state";
            }
        }

        public void setPotentialStates()
        {
            switch (currentState)
            {
                case State.SPACE:
                    previousState = State.HASH;
                    nextState = State.DOT;
                    break;
                case State.DOT:
                    previousState = State.SPACE;
                    nextState = State.PLUS;
                    break;
                case State.PLUS:
                    previousState = State.DOT;
                    nextState = State.HASH;
                    break;
                case State.HASH:
                    previousState = State.PLUS;
                    nextState = State.SPACE;
                    break;
            }
        }

        public State getCurrentState
        {
            get { return currentState; }
        }

        public void setState(State state)
        {
            currentState = state;
        }

        public State getPreviousState
        {
            get { return previousState; }
        }

        public State getNextState
        {
            get { return nextState; }
        }



        public void setStateRandomly(int generatedNumber)
        {
            switch (generatedNumber)
            {
                case 0:
                    currentState = State.SPACE;
                    break;
                case 1:
                    currentState = State.DOT;
                    break;
                case 2:
                    currentState = State.PLUS;
                    break;
                case 3:
                    currentState = State.HASH;
                    break;
            }
        }


    }
}