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

        //copy ctor
        public State(State<T> state)
        {
            this.state = state.state;
            this.cost = state.cost;
            this.cameFrom = state.cameFrom;
        }

        /*
         * overrid the hash code to include just the state
         */
        public override int GetHashCode()
        {
            return state.ToString().GetHashCode();
        }

        /*
         *we overload Object's Equals method
         */
        public bool Equals(State<T> s)
        {
            return state.Equals(s.state);
        }

        //statePool class
        static public class StatePool

        {
            static public Dictionary<T, State<T>> pool = new Dictionary<T, State<T>>();

            static public State<T> getInstance(T current)
            {
                State<T> value;
                bool hasValue = pool.TryGetValue(current, out value);
                if (!hasValue)
                {
                    value = new State<T>(current);
                    pool.Add(current, value);
                }
                return value;
            }
        }
    }
}
