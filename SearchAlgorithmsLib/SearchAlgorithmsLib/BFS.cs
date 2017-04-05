using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    class BFS<T> : Searcher<T>
    {
        HashSet<State<T>> closed;
        public BFS()
        {
            //get the father constructor

            closed = new HashSet<State<T>>();
        }
        // Searcher's abstract method overriding
        public override Solution<T> search(ISearchable<T> searchable)
        {
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList();  // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                    return backTrace(searchable.getGoalState()); // private method, back traces through the parents
                                                                 // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openContaines(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else
                    {
                        if(s.getCost() < getStatePriority(s))
                        {
                            setStatePriority(s);
                        }
                        //ask roi

                    }
                }
            }
        }

        private Solution<T> backTrace(State<T> goal)
        {
            Solution<T> solution = new Solution<T>();
            solution.add(goal);
            State<T> came = goal.getCameFrom();
            while (came != null)
            {
                solution.add(came);
                came = came.getCameFrom();
            }
            return solution;
        }
    }
}
