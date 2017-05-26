using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// class that create a new State from the array. it holds the current State type, 
    /// the cost and from where the State came.
    /// </summary>
    /// <typeparam name="T"> the type of State </typeparam>
    public class State<T>
    {
        public T MyState { get; }
        public float Cost { get; set; } // cost to reach this State (set by a setter)
        public State<T> CameFrom { get; set; } // the State we came from to this State (setter)

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="State"></param>
        public State(T State)
        {
            this.MyState = State;
        }

        /// <summary>
        /// a copy constructor.
        /// </summary>
        /// <param name="States"></param>
        public State(State<T> States)
        {
            this.MyState = States.MyState;
            this.Cost = States.Cost;
            this.CameFrom = States.CameFrom;
        }

        /// <summary>
        /// this function overrides the hash code to include just the State.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return MyState.ToString().GetHashCode();
        }

        /// <summary>
        /// this function overload Object's Equals method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return MyState.Equals((obj as State<T>).MyState);
        }

        /// <summary>
        /// this class is an inner class, defines a State-pool that holds all the Stated created
        /// and make sure that every State is created once.
        /// </summary>
        static public class StatePool

        {
            /// <summary>
            /// a dictionary of States and thier types.
            /// </summary>
            static public Dictionary<T, State<T>> Pool = new Dictionary<T, State<T>>();

            /// <summary>
            /// this function checks if the given State was already created or not.
            /// </summary>
            /// <param name="current">the atate.</param>
            /// <returns></returns>
            static public bool CheckInstance(T current)
            {
                return Pool.ContainsKey(current);
            }


            /// <summary>
            /// this function try to get an instance of a stete. if the State was already
            /// created it returns it. otherwise, creates it, add to the pool and returns.
            /// </summary>
            /// <param name="current"></param>
            /// <returns></returns>
            static public State<T> GetInstance(T current)
            {
                State<T> value;
                bool hasValue = Pool.TryGetValue(current, out value);
                if (!hasValue)
                {
                    value = new State<T>(current);
                    Pool.Add(current, value);
                }
                return value;
            }
        }
    }
}