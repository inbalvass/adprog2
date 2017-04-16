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
        public State(State<T> states)
        {
            this.state = states.state;
            this.cost = states.cost;
            this.cameFrom = states.cameFrom;
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
        public override bool Equals(object obj)
        {
            return state.Equals((obj as State<T>).state);
        }

        //statePool class
        static public class StatePool

        {
            static public Dictionary<T, State<T>> pool = new Dictionary<T, State<T>>();

            static public bool checkInstance(T current)
            {
                return pool.ContainsKey(current);
            }


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
