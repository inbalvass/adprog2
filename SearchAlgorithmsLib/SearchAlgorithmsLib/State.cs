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
        /// a constructor.
        /// </summary>
        /// <param name="state"></param>
        public State(T state)
        {
            this.state = state;
        }

        /// <summary>
        /// a copy constructor.
        /// </summary>
        /// <param name="states"></param>
        public State(State<T> states)
        {
            this.state = states.state;
            this.cost = states.cost;
            this.cameFrom = states.cameFrom;
        }

        /// <summary>
        /// this function overrides the hash code to include just the state.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return state.ToString().GetHashCode();
        }

        /// <summary>
        /// this function overload Object's Equals method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return state.Equals((obj as State<T>).state);
        }

        /// <summary>
        /// this class is an inner class, defines a state-pool that holds all the stated created
        /// and make sure that every state is created once.
        /// </summary>
        static public class StatePool

        {
            /// <summary>
            /// a dictionary of states and thier types.
            /// </summary>
            static public Dictionary<T, State<T>> pool = new Dictionary<T, State<T>>();

            /// <summary>
            /// this function checks if the given state was already created or not.
            /// </summary>
            /// <param name="current">the atate.</param>
            /// <returns></returns>
            static public bool checkInstance(T current)
            {
                return pool.ContainsKey(current);
            }


            /// <summary>
            /// this function try to get an instance of a stete. if the state was already
            /// created it returns it. otherwise, creates it, add to the pool and returns.
            /// </summary>
            /// <param name="current"></param>
            /// <returns></returns>
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