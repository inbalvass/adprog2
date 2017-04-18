using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// class that create a new state from the array. it holds the current state type, 
    /// the cost and from where the state came.
    /// </summary>
    /// <typeparam name="T"> the type of state </typeparam>
    public class State<T>
    {
        public T state { get; }
        public float cost { get; set; } // cost to reach this state (set by a setter)
        public State<T> cameFrom { get; set; } // the state we came from to this state (setter)

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="state"></param>
        public State(T state)
        {
            this.state = state;
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="states"></param>
        public State(State<T> states)
        {
            this.state = states.state;
            this.cost = states.cost;
            this.cameFrom = states.cameFrom;
        }

        /// <summary>
        /// overrid the hash code to include just the state
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return state.ToString().GetHashCode();
        }

        /// <summary>
        /// overload Object's Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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