using System;
using System.Collections.Generic;
using System.Text;
using MazeLib;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this class holdes a solution of some graph.
    /// </summary>
    /// <typeparam name="T"> the type of the State </typeparam>
    public class Solution<T>
    {
        /// <summary>
        /// a list of States that are the solution, and the number of nodes evaluated by 
        /// the Search algorithm that solved the graph.
        /// </summary>
        public List<State<T>> MySolution { get; }
        public int EvaluatedNodes { get; set; }

        /// <summary>
        /// a constructor.
        /// </summary>
        public Solution()
        {
            MySolution = new List<State<T>>();
        }

        /// <summary>
        /// add a new State to the list of solution.
        /// </summary>
        /// <param name="s"></param>
        public void Add(State<T> s)
        {
            MySolution.Add(s);
            return;
        }
    }
}