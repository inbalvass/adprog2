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
        private Dictionary<string, Maze> singleNames;
        private Dictionary<string, Solution<Position>> singleSolutions;
        private Dictionary<string, Maze> multyNames;
        private Dictionary<string, Solution<Position>> multySolutions;

        public Dictionary<string, IMultiGame> multyGames;
        private JArray availableGames;

        public Model(IController conl)
        {
            control = conl;
            singleNames = new Dictionary<string, Maze>();
            singleSolutions = new Dictionary<string, Solution<Position>>();
            multyNames = new Dictionary<string, Maze>();
            multySolutions = new Dictionary<string, Solution<Position>>();
            multyGames = new Dictionary<string, IMultiGame>();
            availableGames = new JArray();
        }

        private ISearchable<Position> getAdapter(string name)
        {
            //need to find the maze in a dictionary.
            Maze maze = singleNames[name];
            ISearchable<Position> adapter = new Adapter(maze);
            return adapter;
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            return Generate(name, rows, cols, singleNames, singleSolutions);
        }

        public Dictionary<string, IMultiGame> getMultyGames()
        {
            return this.multyGames;
        }

        private Maze Generate(string name, int rows, int cols , Dictionary<string, Maze> dicName,
            Dictionary<string, Solution<Position>> dicSolutions)
        {
            //if the name already exist it remove it, and remove the solution if exist
            if (dicName.ContainsKey(name))
            {
                dicName.Remove(name);
                if (dicSolutions.ContainsKey(name))
                {
                    dicSolutions.Remove(name);
                }
            }
            Console.WriteLine(name + rows + cols);
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            Maze maze = mazeGenerate.Generate(rows, cols);
            maze.Name = name;
            Console.WriteLine(maze);
            dicName.Add(name, maze);
            return maze;
        }

        public string SolveMazeCommand(string name, int algorithm)
        {
            ISearchable<Position> adapter = getAdapter(name);
            Solution<Position> sol;
            int evaluated = 0;
            if (singleSolutions.ContainsKey(name))
            {
                sol = singleSolutions[name];
            }
            else
            {
                if (algorithm == 0)
                {
                    BFS<Position> bfs = new BFS<Position>();
                    sol = bfs.search(adapter);
                    evaluated = bfs.getNumberOfNodesEvaluated();
                    singleSolutions.Add(name, sol);
                }
                else
                {
                    DFS<Position> dfs = new DFS<Position>();
                    sol = dfs.search(adapter);
                    evaluated = dfs.getNumberOfNodesEvaluated();
                    singleSolutions.Add(name, sol);
                }
            }
            FindDirections f = new FindDirections();
            f.listOfDirections(sol);
            string strList = f.fromListToString();
            return f.ToJson(name, evaluated);
        }


        public string StartMazeCommand(string name, int rows, int cols,IMultiGame game)
        {
            //create the maze
            Maze maze = Generate(name, rows, cols, multyNames, multySolutions);
            game.setMaze(maze);
            multyGames.Add(name, game);
            //add the name to the available games to join
            availableGames.Add(name);
            return maze.ToJSON();
        }

        public string ListCommand()
        {
            return availableGames.ToString();
        }

        public IMultiGame JoinCommand(string name)
        {
            //לראות איך לעשות את זה נכון
            if (!availableGames.Contains(name))
            {
                //"wrong input-game not exist";
                //throw Exception("wrong input-game not exist");
            }
            availableGames.Remove(name);
            return multyGames[name];
        }

        public string PlayCommand(string move)
        {
            return move;
        }

        public IMultiGame CloseCommand(string name)
        {
            IMultiGame game = multyGames[name];
            multyGames.Remove(name);
            return game;
        }
    }
}
