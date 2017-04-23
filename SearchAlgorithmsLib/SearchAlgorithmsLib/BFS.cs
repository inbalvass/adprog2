using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this class represents the BFS algorithm logic, implements the Searcher interface.
    /// </summary>
    /// <typeparam name="T">the algorithm is generic.
    /// </typeparam>
    public class BFS<T> : Searcher<T>
    {
        /// <summary>
        /// the open list of stats we have not visited.
        /// </summary>
        private Priority_Queue.SimplePriorityQueue<State<T>> openList;


        /// <summary>
        /// this function search the goal state in the garph, and overriding
        /// Searcher's abstract method.
        /// </summary>
        /// <param name="searchable"> a searchable object to search in graph.
        /// </param>
        /// <returns></returns>
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
                    Solution<T> sol = backTrace(n, searchable.getInitialState());
                    sol.evaluatedNodes = getNumberOfNodesEvaluated();
                    return sol;
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

        /// <summary>
        /// this function finds a specific state in the open list.
        /// </summary>
        /// <param name="s">the state to search for.
        /// </param>
        /// <returns></returns>
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

        /// <summary>
        /// this function returns the priority in the open list of a specific state.
        /// </summary>
        /// <param name="s">the state.
        /// </param>
        /// <returns>the priority.
        /// </returns>
        private float getStatePriorityInOpen(State<T> s)
        {
            State<T> current = findStateInQueue(s);
            return current.cost;
        }

        /// <summary>
        /// this dunction sets the priority of a specific state in the open list.
        /// </summary>
        /// <param name="s">the state.
        /// </param>
        private void setStatePriorityInOpen(State<T> s)
        {
            openList.Remove(s);
            //need to update the cost and also set to new father
            openList.Enqueue(s, s.cost);
        }
    }
}