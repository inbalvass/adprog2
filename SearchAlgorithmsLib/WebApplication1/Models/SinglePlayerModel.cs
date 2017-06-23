using checksTheDll;
using MazeGeneratorLib;
using MazeLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server;

namespace WebServer.Models
{
    public class SinglePlayerModel
    {
        //public string Name { get; set; }
        //public int Rows { get; set; }
        //public int Cols { get; set; }

        /// dictionary to save the mazes in the single games
        /// </summary>
        static private Dictionary<string, Maze> singleNames = new Dictionary<string, Maze>();
        /// <summary>
        /// dictionary to save the solution for the single games
        /// </summary>
        static private Dictionary<string, Solution<Position>> singleSolutions = new Dictionary<string, Solution<Position>>();

        public string GetMazeStr(string name, int rows, int cols)
        {
            Maze maze;
            if (!singleNames.Keys.Contains(name))
            {
                DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
                maze = mazeGenerate.Generate(rows, cols);
                maze.Name = name;
                singleNames.Add(name, maze);
            }
            else
            {
                maze = singleNames[name];
            }    
            string mazeStr = maze.ToJSON();
            return mazeStr;
        }

        public string GetSolution(string name, int algo)
        {
            Maze maze = singleNames[name];
            ISearchable<Position> adapter = new server.Adapter(maze);
            Solution<Position> sol;
            int evaluated;
            if (singleSolutions.ContainsKey(name))
            {
                sol = singleSolutions[name];
                evaluated = sol.EvaluatedNodes;
            }
            else
            {
                if (algo == 0)
                {
                    BFS<Position> bfs = new BFS<Position>();
                    sol = bfs.Search(adapter);
                    evaluated = bfs.GetNumberOfNodesEvaluated();
                    singleSolutions.Add(name, sol);///////
                }
                else
                {
                    DFS<Position> dfs = new DFS<Position>();
                    sol = dfs.Search(adapter);
                    evaluated = dfs.GetNumberOfNodesEvaluated();
                    singleSolutions.Add(name, sol);///////
                }
            }
            FindDirections f = new FindDirections();
            f.ListOfDirections(sol);
            string strList = f.FromListToString();
            return f.ToJson(name, evaluated);
        }
    }
}