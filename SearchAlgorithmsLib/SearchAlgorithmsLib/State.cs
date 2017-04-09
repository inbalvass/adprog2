using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public class State<T>
    {
        public T state { get; }
        public float cost { get; set; } // cost to reach this state (set by a setter)
        public State<T> cameFrom { get; set; } // the state we came from to this state (setter)
        /*
         * CTOR
         */
        public State(T state) 
        {
            this.state = state;
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
