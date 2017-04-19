using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace server
{
    class Model : IModel
    {
        private IController control;
        private Dictionary<string, Maze> names;
        private Dictionary<string, Solution<Position>> solutions;
        private JArray availableGames;

        public Model(IController conl)
        {
            control = conl;
            names = new Dictionary<string, Maze>();
            solutions = new Dictionary<string, Solution<Position>>();
            availableGames = new JArray();
        }

        private ISearchable<Position> getAdapter(string name)
        {
            //need to find the maze in a dictionary.
            Maze maze = names[name];
            ISearchable<Position> adapter = new Adapter(maze);
            return adapter;
        }

        //if the name already exist it return the maze, otherwise it generate new maze
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            if (names.ContainsKey(name))
            {
                return names[name];
            }
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            Maze maze = mazeGenerate.Generate(rows, cols);
            names.Add(name, maze);
            return maze;
        }

        public string SolveMazeCommand(string name, int algorithm)
        {
            ISearchable<Position> adapter = getAdapter(name);
            Solution<Position> sol;
            int evaluated = 0;
            if (solutions.ContainsKey(name))
            {
                sol = solutions[name];
            }
            else
            {
                if (algorithm == 0)
                {
                    BFS<Position> bfs = new BFS<Position>();
                    sol = bfs.search(adapter);
                    evaluated = bfs.getNumberOfNodesEvaluated();
                    solutions.Add(name, sol);
                }
                else
                {
                    DFS<Position> dfs = new DFS<Position>();
                    sol = dfs.search(adapter);
                    evaluated = dfs.getNumberOfNodesEvaluated();
                    solutions.Add(name, sol);
                }
            }
            FindDirections f = new FindDirections();
            f.listOfDirections(sol);
            string strList = f.fromListToString();
            return f.ToJson(name, evaluated);
        }


        public string StartMazeCommand(string name, int rows, int cols)
        {
            //add the name to the available games to join
            availableGames.Add(name);
            return "ss";
        }

        public string ListCommand()
        {
            return availableGames.ToString();
        }

        public string JoinCommand(string name)
        {
            //remove the name from the list because the game is no longer available
            availableGames.Remove(name);
            return "ss";
        }

        public string PlayCommand(string move)
        {
            return "ss";
        }
        public string CloseCommand(string name)
        {
            return "ss";
        }
    }
}
