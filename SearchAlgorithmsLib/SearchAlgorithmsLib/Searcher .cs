using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        //private int evaluatedNodes;
        private HashSet<State<T>> closed;
        private int evaluatedNodes;

        public Searcher()
        {
            evaluatedNodes = 0;
            closed = new HashSet<State<T>>();
        }

        protected void addToClosedList(State<T> s)
        {
            closed.Add(s);
        } 

        protected bool closedContains(State<T> s)
        {
            return closed.Contains(s);
        }

        protected Solution<T> backTrace(State<T> goal)
        {
            Solution<T> solution = new Solution<T>();
            solution.add(goal);
            State<T> came = goal.cameFrom;
            while (came != null)
            {
                solution.add(came);
                came = came.cameFrom;
            }
            return solution;
        }

        // ISearcher’s methods: 
        //this is not correct. it need to count how many nodes get in the open list!!!
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public void setNumberOfNodesEvaluated()
        {
            evaluatedNodes++;
        }
        public abstract Solution<T> search(ISearchable<T> searchable);
    }
}
