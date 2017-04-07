using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.ISearchable<T>;
using MazeLib.Maze;
using System.Collections.Generic;

namespace checksTheDll
{
    public class Adapter : ISearchable<T>
    {
        private Maze maze;


        public ISearchable<T> Adapter(Maze m)
        {

        }
        State<T> getInitialState();
        State<T> getGoalState();
        List<State<T>> getAllPossibleStates(State<T> s);
    }
}
