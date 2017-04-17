using System;
using System.Collections.Generic;
using System.Text;

using MazeGeneratorLib;
using MazeLib;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : Searcher<T>
    {
        public override Solution<T> search(ISearchable<T> searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            stack.Push(searchable.getInitialState());
            State<T> node;
            while(stack.Count != 0)
            {
                node = stack.Pop();
                //if we found the goal then return the trace
                if (node.Equals(searchable.getGoalState()))
                {
                    return backTrace(searchable.getGoalState(), searchable.getInitialState());
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