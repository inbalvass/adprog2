using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public interface ISearcher<T>
    {
        /// <summary>
        /// search in the graph
        /// </summary>
        /// <param name="searchable"> the graph to cearch in</param>
        /// <returns></returns>
        Solution<T> search(ISearchable<T> searchable);

        /// <summary>
        /// get how many nodes were evaluated by the algorithm
        /// </summary>
        /// <returns></returns>
        int getNumberOfNodesEvaluated();
    }
}