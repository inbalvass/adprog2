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
            openList.Enqueue(searchable.getInitialState(), searchable.getInitialState().cost); // inherited from Searcher
            bool openContainsS, closedContainsS;
            while (openList.Count > 0)
            {
                State<T> n = openList.Dequeue();  
                addToClosedList(n);
                if (n.Equals(searchable.getGoalState()))
                    return backTrace(searchable.getGoalState()); // private method, back traces through the parents
                                                                 // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    openContainsS = openList.Contains(s);
                    closedContainsS = closedContains(s);
                    if (!closedContainsS && !openContainsS)
                    {
                        //צריך לוודא שכאשר מקבלים את הבנים שהוא
                        //כבר מעדכן את העלות...או שזה יהיה דרך הקומפרטור?
                        // s.setCameFrom(n);  // already done by getSuccessors
                        openList.Enqueue(s,s.cost);
                        setNumberOfNodesEvaluated();
                    }
                    else
                    {
                        if (!openContainsS && !(n.cameFrom.Equals(s)))
                        {
                            openList.Enqueue(s, s.cost);
                            setNumberOfNodesEvaluated();
                        }
                        else if(openContainsS && (s.cost < getStatePriorityInOpen(s)))
                        {
                            setStatePriorityInOpen(s);
                        }
                    }
                }
            }
            return backTrace(searchable.getGoalState());
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
            openList.UpdatePriority(s, s.cost);
        }
    }
}
