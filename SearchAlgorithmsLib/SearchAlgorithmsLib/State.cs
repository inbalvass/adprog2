using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public class State<T>
    {
        private T state;
        private float cost; // cost to reach this state (set by a setter)
        private State<T> cameFrom; // the state we came from to this state (setter)
        /*
         * CTOR
         */
        public State(T state) 
        {
            this.state = state;
        }

        public float getCost()
        {
            return cost;
        }

        public State<T> getCameFrom()
        {
            return cameFrom;
        }

        /*
         *we overload Object's Equals method
         */
        public bool Equals(State<T> s) 
        {
            return state.Equals(s.state);
        }
    }
}
