using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private Priority_Queue.SimplePriorityQueue<State<T>> openList;
        private int evaluatedNodes;

        public Searcher()
        {
            openList = new Priority_Queue.SimplePriorityQueue<State<T>>();
            evaluatedNodes = 0;
        }

        protected void addToOpenList(State<T> state)
        {
            openList.Enqueue(state, state.getCost());
        }

        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();//if it empty it send execption so need to check it
                                      // return openList.poll();//the original line
        }

        protected bool openContaines(State<T> s)
        {
            return openList.Contains(s);
        }

        private State<T> findStateInQueue(State<T> s)
        {
            Priority_Queue.SimplePriorityQueue<State<T>> help = new Priority_Queue.SimplePriorityQueue<State<T>>();
            State<T> current;
            State<T> sHelp;
            while (!openList.First.Equals(s))
            {
                sHelp = openList.Dequeue();
                help.Enqueue(sHelp, sHelp.getCost());//remove the head of the queue and save it in the list
            }
            current= openList.First;
            while (help.Count != 0)
            {
                sHelp = help.Dequeue();
                openList.Enqueue(sHelp, sHelp.getCost());
            }
            return current;
        }

        protected float getStatePriority(State<T> s)
        {
            State<T> current = findStateInQueue(s);
            return current.getCost();
        }

        protected void setStatePriority(State<T> s)
        {
            openList.UpdatePriority(s, s.getCost());
        }

        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        // ISearcher’s methods: 

        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public abstract Solution<T> search(ISearchable<T> searchable);

    }
}
