using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// this interface defines an object that can be Searched in.
    /// </summary>
    /// <typeparam name="T">generic.</typeparam>
    public interface ISearchable<T>
    {
        /// <summary>
        /// this function returns the initial State (start point) of the Searchable.
        /// </summary>
        /// <returns>the initial State.
        /// </returns>
        State<T> GetInitialState();

        /// <summary>
        /// this function returns the goal State (end point) of the Searchable.
        /// </summary>
        /// <returns>the goal State.
        /// </returns>
        State<T> GetGoalState();

        /// <summary>
        /// this function calculates a list of all the possible States to go to,
        /// from a specific State.
        /// </summary>
        /// <param name="s"> the State.
        /// </param>
        /// <returns> the list of thates.
        /// </returns>
        List<State<T>> GetAllPossibleStates(State<T> s);
    }
}