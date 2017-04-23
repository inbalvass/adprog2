using System;
using System.Collections.Generic;
using System.Text;

using MazeGeneratorLib;
using MazeLib;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this class represents the DFS algorithm logic, implements the Searcher interface.
    /// </summary>
    /// <typeparam name="T">the algorithm is generic.
    /// </typeparam>
    public class DFS<T> : Searcher<T>
    {
        /// <summary>
        /// this function search the goal state in the garph, and overriding
        /// Searcher's abstract method.
        /// </summary>
        /// <param name="searchable"> a searchable object to search in graph.
        /// </param>
        /// <returns></returns>
        public override Solution<T> search(ISearchable<T> searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            stack.Push(searchable.getInitialState());
            State<T> node;
            while (stack.Count != 0)
            {
                node = stack.Pop();
                //if we found the goal then return the trace
                if (node.Equals(searchable.getGoalState()))
                {
                    Solution<T> sol = backTrace(searchable.getGoalState(), searchable.getInitialState());
                    sol.evaluatedNodes = getNumberOfNodesEvaluated();
                    return sol;
                }
                if (!closedContains(node))
                {

                    addToClosedList(node);
                    List<State<T>> succerssors = searchable.getAllPossibleStates(node);
                    foreach (State<T> s in succerssors)
                    {
                        if (closedContains(s))
                        {
                            //if the node it in the close list so no need to open it again
                            continue;
                        }
                        State<T> st = new State<T>(s);
                        stack.Push(st);
                        setNumberOfNodesEvaluated();
                    }
                }
            }
            //if the program is here means the goal has not found.
            throw new InvalidOperationException("Goal state has not found");
        }
    }
}