using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public class BFS<T> : Searcher<T>
    {
        private Priority_Queue.SimplePriorityQueue<State<T>> openList;

        // Searcher's abstract method overriding
        public override Solution<T> search(ISearchable<T> searchable)
        {
            openList = new Priority_Queue.SimplePriorityQueue<State<T>>();
            openList.Enqueue(searchable.getInitialState(), searchable.getInitialState().cost);
            bool openContainsS, closedContainsS;
            State<T> goal = searchable.getGoalState();
            while (openList.Count > 0)
            {
                State<T> n = openList.Dequeue();
                addToClosedList(n);
                if (n.Equals(goal))
                {
                    return backTrace(n, searchable.getInitialState());
                }
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {

                    openContainsS = openList.Contains(s);
                    closedContainsS = closedContains(s);
                    State<T> st = new State<T>(s);
                    if (!closedContainsS && !openContainsS)
                    {
                        openList.Enqueue(st, st.cost);
                        setNumberOfNodesEvaluated();
                    }
                    else
                    {
                        if (!openContainsS && !(n.cameFrom.Equals(st)))
                        {
                            openList.Enqueue(st, st.cost);
                            setNumberOfNodesEvaluated();
                        }
                        else if (openContainsS && (st.cost < getStatePriorityInOpen(st)))
                        {
                            setStatePriorityInOpen(st);
                        }
                    }
                }
            }
            //if the program is here means the goal has not found.
            throw new InvalidOperationException("Goal state has not found");
        }

        private State<T> findStateInQueue(State<T> s)
        {
            Priority_Queue.SimplePriorityQueue<State<T>> help = new Priority_Queue.SimplePriorityQueue<State<T>>();
            State<T> current;
            State<T> sHelp;
            while (!openList.First.Equals(s))
            {
                sHelp = openList.Dequeue();
                help.Enqueue(sHelp, sHelp.cost);//remove the head of the queue and save it in the list
            }
            current = openList.First;
            while (help.Count != 0)
            {
                sHelp = help.Dequeue();
                openList.Enqueue(sHelp, sHelp.cost);
            }
            return current;
        }

        private float getStatePriorityInOpen(State<T> s)
        {
            State<T> current = findStateInQueue(s);
            return current.cost;
        }

        private void setStatePriorityInOpen(State<T> s)
        {
            openList.Remove(s);
            //need to update the cost and also set to new father
            openList.Enqueue(s, s.cost);
        }
    }
}