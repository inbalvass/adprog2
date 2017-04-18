using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace server
{
    interface IModel
    {
        ISearchable<Position> getAdapter(string name);
        Maze GenerateMaze(string name, int rows, int cols);
    }
}
