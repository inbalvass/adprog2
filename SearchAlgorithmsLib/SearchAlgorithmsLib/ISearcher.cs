using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this interface defines an object that can perform a search algorithm.
    /// </summary>
    /// <typeparam name="T">generic. </typeparam>
    public interface ISearcher<T>
    {
        /// <summary>
        /// this function search in the graph the goal state
        /// </summary>
        /// <param name="searchable"> the graph to cearch in.
        /// </param>
        /// <returns>the solution of the graph = the rout.
        /// </returns>
        Solution<T> search(ISearchable<T> searchable);

        /// <summary>
        /// get how many nodes were evaluated by the algorithm.
        /// </summary>
        /// <returns></returns>
        int getNumberOfNodesEvaluated();
    }
}