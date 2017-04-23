using System;
using System.Collections.Generic;
using System.Text;
using MazeLib;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// create a list of the solution
    /// </summary>
    /// <typeparam name="T"> the type of the state </typeparam>
    public class Solution<T>
    {
        public List<State<T>> solution { get; }
        public int evaluatedNodes { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public Solution()
        {
            solution = new List<State<T>>();
        }

        /// <summary>
        /// add new state to the list of solution
        /// </summary>
        /// <param name="s"></param>
        public void add(State<T> s)
        {
            solution.Add(s);
            return;
        }
    }
}