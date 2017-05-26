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
        /// this function Search the goal State in the garph, and overriding
        /// Searcher's abstract method.
        /// </summary>
        /// <param name="Searchable"> a Searchable object to Search in graph.
        /// </param>
        /// <returns></returns>
        public override Solution<T> Search(ISearchable<T> Searchable)
        {
            openList = new Priority_Queue.SimplePriorityQueue<State<T>>();
            openList.Enqueue(Searchable.GetInitialState(), Searchable.GetInitialState().Cost);
            bool openContainsS, closedContainsS;
            State<T> goal = Searchable.GetGoalState();
            while (openList.Count > 0)
            {
                State<T> n = openList.Dequeue();
                AddToClosedList(n);
                if (n.Equals(goal))
                {
                    Solution<T> sol = BackTrace(n, Searchable.GetInitialState());
                    sol.EvaluatedNodes = GetNumberOfNodesEvaluated();
                    return sol;
                }
                List<State<T>> succerssors = Searchable.GetAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {

                    openContainsS = openList.Contains(s);
                    closedContainsS = ClosedContains(s);
                    State<T> st = new State<T>(s);
                    if (!closedContainsS && !openContainsS)
                    {
                        openList.Enqueue(st, st.Cost);
                        SetNumberOfNodesEvaluated();
                    }
                    else
                    {
                        if (!openContainsS && !(n.CameFrom.Equals(st)))
                        {
                            openList.Enqueue(st, st.Cost);
                            SetNumberOfNodesEvaluated();
                        }
                        else if (openContainsS && (st.Cost < GetStatePriorityInOpen(st)))
                        {
                            SetStatePriorityInOpen(st);
                        }
                    }
                }
            }
            //if the program is here means the goal has not found.
            throw new InvalidOperationException("Goal State has not found");
        }

        /// <summary>
        /// this function finds a specific State in the open list.
        /// </summary>
        /// <param name="s">the State to Search for.
        /// </param>
        /// <returns></returns>
        private State<T> FindStateInQueue(State<T> s)
        {
            Priority_Queue.SimplePriorityQueue<State<T>> help = new Priority_Queue.SimplePriorityQueue<State<T>>();
            State<T> current;
            State<T> sHelp;
            while (!openList.First.Equals(s))
            {
                sHelp = openList.Dequeue();
                help.Enqueue(sHelp, sHelp.Cost);//remove the head of the queue and save it in the list
            }
            current = openList.First;
            while (help.Count != 0)
            {
                sHelp = help.Dequeue();
                openList.Enqueue(sHelp, sHelp.Cost);
            }
            return current;
        }

        /// <summary>
        /// this function returns the priority in the open list of a specific State.
        /// </summary>
        /// <param name="s">the State.
        /// </param>
        /// <returns>the priority.
        /// </returns>
        private float GetStatePriorityInOpen(State<T> s)
        {
            State<T> current = FindStateInQueue(s);
            return current.Cost;
        }

        /// <summary>
        /// this dunction sets the priority of a specific State in the open list.
        /// </summary>
        /// <param name="s">the State.
        /// </param>
        private void SetStatePriorityInOpen(State<T> s)
        {
            openList.Remove(s);
            //need to update the cost and also set to new father
            openList.Enqueue(s, s.Cost);
        }
    }
}