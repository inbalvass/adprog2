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
        Maze GenerateMaze(string name, int rows, int cols);
        String SolveMazeCommand(string name, int algorithm);
        string StartMazeCommand(string name, int rows, int cols);
        string ListCommand();
        string JoinCommand(string name);
        string PlayCommand(string move);
        string CloseCommand(string name);
    }
}
