using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this class defines an object that can perform a Search algorithm, and holds
    /// a closed list of nodes as part of the algorithm.
    /// </summary>
    /// <typeparam name="T">generic. </typeparam>
    public abstract class Searcher<T> : ISearcher<T>
    {
        /// <summary>
        /// a closed list of nodes (evaluated), and the number of nodes evaluated.
        /// </summary>
        private HashSet<State<T>> closed;
        private int evaluatedNodes;

        /// <summary>
        /// constructor
        /// </summary>
        public Searcher()
        {
            evaluatedNodes = 0;
            closed = new HashSet<State<T>>();
        }

        /// <summary>
        /// add new State to the close list
        /// </summary>
        /// <param name="s">the State to add</param>
        protected void AddToClosedList(State<T> s)
        {
            closed.Add(s);
        }

        /// <summary>
        /// return how many items in the list
        /// </summary>
        /// <returns> how many items in the list</returns>
        protected int CountClosedList()
        {
            return closed.Count;
        }

        /// <summary>
        /// check if the close list contain item s and retur true or false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected bool ClosedContains(State<T> s)
        {
            return closed.Contains(s);
        }

        /// <summary>
        /// create the solution and return it
        /// </summary>
        /// <param name="goal"> the goal State</param>
        /// <param name="start"> the start State</param>
        /// <returns></returns>
        public Solution<T> BackTrace(State<T> goal, State<T> start)
        {
            Solution<T> solution = new Solution<T>();
            solution.Add(goal);
            State<T> came = goal.CameFrom;
            while (!came.Equals(start) && came != null)
            {
                solution.Add(came);
                came = came.CameFrom;
            }
            solution.Add(start);
            return solution;
        }

        /// <summary>
        /// return the number of evaluated nodes
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        /// <summary>
        /// set the number of the evaluated nodes
        /// </summary>
        public void SetNumberOfNodesEvaluated()
        {
            evaluatedNodes++;
        }

        /// <summary>
        /// Search in the graph
        /// </summary>
        /// <param name="Searchable"> the graph to cearch in</param>
        /// <returns></returns>
        public abstract Solution<T> Search(ISearchable<T> Searchable);
    }
}