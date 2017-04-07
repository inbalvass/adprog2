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

        public Searcher()
        {
            //evaluatedNodes = 0;
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
            State<T> came = goal.getCameFrom();
            while (came != null)
            {
                solution.add(came);
                came = came.getCameFrom();
            }
            return solution;
        }

        // ISearcher’s methods: 
        public int getNumberOfNodesEvaluated()
        {
            return closed.Count;
        }
        public abstract Solution<T> search(ISearchable<T> searchable);
    }
}
