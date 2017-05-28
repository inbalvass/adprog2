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
    /// <summary>
    /// the model
    /// </summary>
    class Model : IModel
    {
        /// <summary>
        /// the controller
        /// </summary>
        private IController control;
        /// <summary>
        /// dictionary to save the mazes in the single games
        /// </summary>
        private Dictionary<string, Maze> singleNames;
        /// <summary>
        /// dictionary to save the solution for the single games
        /// </summary>
        private Dictionary<string, Solution<Position>> singleSolutions;
        /// <summary>
        /// dictionary to save the mazes in the multy games
        /// </summary>
        private Dictionary<string, Maze> multyNames;
        /// <summary>
        /// dictionary to save the solution for the multy games
        /// </summary>
        private Dictionary<string, Solution<Position>> multySolutions;
        /// <summary>
        /// dictionary to save the information of the multy games
        /// </summary>
        public Dictionary<string, IMultiGame> multyGames;
        /// <summary>
        /// array to save the names of the available games to join in
        /// </summary>
        private List<string> listAvailableGames;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="conl"> the controller</param>
        public Model(IController conl)
        {
            control = conl;
            singleNames = new Dictionary<string, Maze>();
            singleSolutions = new Dictionary<string, Solution<Position>>();
            multyNames = new Dictionary<string, Maze>();
            multySolutions = new Dictionary<string, Solution<Position>>();
            multyGames = new Dictionary<string, IMultiGame>();
            listAvailableGames = new List<string>();
        }

        /// <summary>
        /// create an adapter and return it
        /// </summary>
        /// <param name="name"> the maze name</param>
        /// <returns></returns>
        private ISearchable<Position> getAdapter(string name)
        {
            if (!singleNames.ContainsKey(name))
            {
                throw new System.ArgumentException("wrong input - game not exist", "original");
            }
            //need to find the maze in a dictionary.
            Maze maze = singleNames[name];
            ISearchable<Position> adapter = new Adapter(maze);
            return adapter;
        }

        /// <summary>
        /// generate maze for single player
        /// </summary>
        /// <param name="name"> the maze name</param>
        /// <param name="rows">the number of rows</param>
        /// <param name="cols"> the number of colomns</param>
        /// <returns></returns>
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            return Generate(name, rows, cols, singleNames, singleSolutions);
        }

        public Dictionary<string, IMultiGame> GetMultyGames()
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

        /// <summary>
        /// 
        /// this function solves the maze for a single player.
        /// </summary>
        /// <param name="name">the name of the maze to solve</param>
        /// <param name="algorithm">the algorithm to solve the maze with</param>
        /// <returns></returns>
        public string SolveMazeCommand(string name, int algorithm)
        {
            ISearchable<Position> adapter = getAdapter(name);
            Solution<Position> sol;
            int evaluated;
            if (singleSolutions.ContainsKey(name))
            {
                sol = singleSolutions[name];
                evaluated = sol.EvaluatedNodes;
            }
            else
            {
                if (algorithm == 0)
                {
                    BFS<Position> bfs = new BFS<Position>();
                    sol = bfs.Search(adapter);
                    evaluated = bfs.GetNumberOfNodesEvaluated();
                    singleSolutions.Add(name, sol);
                }
                else
                {
                    DFS<Position> dfs = new DFS<Position>();
                    sol = dfs.Search(adapter);
                    evaluated = dfs.GetNumberOfNodesEvaluated();
                    singleSolutions.Add(name, sol);
                }
            }
            FindDirections f = new FindDirections();
            f.ListOfDirections(sol);
            string strList = f.FromListToString();
            return f.ToJson(name, evaluated);
        }

        /// <summary>
        /// this function starts a MultiPlayer game.
        /// </summary>
        /// <param name="name">name of the game</param>
        /// <param name="rows">rows in the maze</param>
        /// <param name="cols">columns in the maze</param>
        /// <param name="game">the game</param>
        /// <returns></returns>
        public string StartMazeCommand(string name, int rows, int cols,IMultiGame game)
        {
            //create the maze
            Maze maze = Generate(name, rows, cols, multyNames, multySolutions);
            game.SetMaze(maze);
            multyGames.Add(name, game);
            //add the name to the available games to join
            Console.WriteLine(name);
            listAvailableGames.Add(name);
            Console.WriteLine(listAvailableGames.Contains(name));
            return maze.ToJSON();
        }

        /// <summary>
        /// this function lists all the possible games to join to.
        /// </summary>
        /// <returns></returns>
        public string ListCommand()
        {
            JArray availableGames = new JArray();
            availableGames = JArray.FromObject(listAvailableGames);
            return availableGames.ToString();
        }

        /// <summary>
        /// this function join a player to an existing game.
        /// </summary>
        /// <param name="name">the name of the game.</param>
        /// <returns></returns>
        public IMultiGame JoinCommand(string name)
        {
            listAvailableGames.Remove(name);
            return multyGames[name];
        }

        /// <summary>
        /// this function play a move of a player in a multiplater game.
        /// </summary>
        /// <param name="move">up/down etc..</param>
        /// <returns></returns>
        public string PlayCommand(string move)
        {
            return move;
        }

        /// <summary>
        /// this function close the connection of the client to the server and the game.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IMultiGame CloseCommand(string name)
        {
            if (!multyGames.ContainsKey(name))
            {
                throw new System.ArgumentException("wrong input - game not exist", "original");
            }
            IMultiGame game = multyGames[name];
            multyGames.Remove(name);
            return game;
        }
    }
}
