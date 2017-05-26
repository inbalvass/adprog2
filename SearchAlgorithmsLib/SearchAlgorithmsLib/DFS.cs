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
        /// this function Search the goal State in the garph, and overriding
        /// Searcher's abstract method.
        /// </summary>
        /// <param name="Searchable"> a Searchable object to Search in graph.
        /// </param>
        /// <returns></returns>
        public override Solution<T> Search(ISearchable<T> Searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            stack.Push(Searchable.GetInitialState());
            State<T> node;
            while (stack.Count != 0)
            {
                node = stack.Pop();
                //if we found the goal then return the trace
                if (node.Equals(Searchable.GetGoalState()))
                {
                    Solution<T> sol = BackTrace(Searchable.GetGoalState(), Searchable.GetInitialState());
                    sol.EvaluatedNodes = GetNumberOfNodesEvaluated();
                    return sol;
                }
                if (!ClosedContains(node))
                {

                    AddToClosedList(node);
                    List<State<T>> succerssors = Searchable.GetAllPossibleStates(node);
                    foreach (State<T> s in succerssors)
                    {
                        if (ClosedContains(s))
                        {
                            //if the node it in the close list so no need to open it again
                            continue;
                        }
                        State<T> st = new State<T>(s);
                        stack.Push(st);
                        SetNumberOfNodesEvaluated();
                    }
                }
            }
            //if the program is here means the goal has not found.
            throw new InvalidOperationException("Goal State has not found");
        }
    }
}