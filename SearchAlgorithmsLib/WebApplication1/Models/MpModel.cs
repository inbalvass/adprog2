using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MpModel
    {
        //dictionary of players ID's and maze names
        static public Dictionary<string, List<string>> MazeNamesToPlayers =
            new Dictionary<string, List<string>>();
        static public Dictionary<string, Maze> NamesToMazes = new Dictionary<string, Maze>();

        /// <summary>
        /// create new maze logic.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public Maze CreateMaze(string name, int rows, int cols)
        {
            Maze maze;
            if (!NamesToMazes.Keys.Contains(name))
            {
                DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
                maze = mazeGenerate.Generate(rows, cols);
                maze.Name = name;
                NamesToMazes.Add(name, maze);
            }
            else
            {
                maze = NamesToMazes[name];
            }
            return maze;
        }
    }
}