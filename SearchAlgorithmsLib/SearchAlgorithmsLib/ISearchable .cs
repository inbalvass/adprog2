using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this interface defines an object that can be searched in.
    /// </summary>
    /// <typeparam name="T">generic.</typeparam>
    public interface ISearchable<T>
    {
        /// <summary>
        /// this function returns the initial state (start point) of the searchable.
        /// </summary>
        /// <returns>the initial state.
        /// </returns>
        State<T> getInitialState();

        /// <summary>
        /// this function returns the goal state (end point) of the searchable.
        /// </summary>
        /// <returns>the goal state.
        /// </returns>
        State<T> getGoalState();

        /// <summary>
        /// this function calculates a list of all the possible states to go to,
        /// from a specific state.
        /// </summary>
        /// <param name="s"> the state.
        /// </param>
        /// <returns> the list of thates.
        /// </returns>
        List<State<T>> getAllPossibleStates(State<T> s);
    }
}