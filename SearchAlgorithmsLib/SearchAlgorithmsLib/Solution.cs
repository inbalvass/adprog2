using System;
using System.Collections.Generic;
using System.Text;
using MazeLib;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this class holdes a solution of some graph.
    /// </summary>
    /// <typeparam name="T"> the type of the state </typeparam>
    public class Solution<T>
    {
        /// <summary>
        /// a list of states that are the solution, and the number of nodes evaluated by 
        /// the search algorithm that solved the graph.
        /// </summary>
        public List<State<T>> solution { get; }
        public int evaluatedNodes { get; set; }

        /// <summary>
        /// a constructor.
        /// </summary>
        public Solution()
        {
            solution = new List<State<T>>();
        }

        /// <summary>
        /// add a new state to the list of solution.
        /// </summary>
        /// <param name="s"></param>
        public void add(State<T> s)
        {
            solution.Add(s);
            return;
        }
    }
}