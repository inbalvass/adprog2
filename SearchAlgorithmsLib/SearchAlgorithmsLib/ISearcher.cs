using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this interface defines an object that can perform a Search algorithm.
    /// </summary>
    /// <typeparam name="T">generic. </typeparam>
    public interface ISearcher<T>
    {
        /// <summary>
        /// this function Search in the graph the goal State
        /// </summary>
        /// <param name="Searchable"> the graph to cearch in.
        /// </param>
        /// <returns>the solution of the graph = the rout.
        /// </returns>
        Solution<T> Search(ISearchable<T> Searchable);

        /// <summary>
        /// get how many nodes were evaluated by the algorithm.
        /// </summary>
        /// <returns></returns>
        int GetNumberOfNodesEvaluated();
    }
}