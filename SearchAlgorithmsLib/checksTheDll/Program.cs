using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;


namespace checksTheDll
{
    /// <summary>
    /// run the main and create maze and solve it with bfs and dfs
    /// </summary>
    class Program
    {
        private Maze maze;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Program(int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            maze = mazeGenerate.Generate(rows, cols);
        }

        /// <summary>
        /// this function compares the BFS and DFS algorithms, by solving the same maze.
        /// </summary>
        public void CompareSolvers()
        {
            Console.WriteLine(maze.ToString());
            Adapter adp = new Adapter(maze);
            if (adp.GetGoalState().Equals(adp.GetInitialState()))
            {
                Console.WriteLine("start and goal in the same place");
                return;
            }

            BFS<Position> bfs = new BFS<Position>();
            bfs.Search(adp);
            Console.WriteLine("bfs open" + bfs.GetNumberOfNodesEvaluated() + "nodes");

            DFS<Position> dfs = new DFS<Position>();
            dfs.Search(adp);
            Console.WriteLine("dfs open" + dfs.GetNumberOfNodesEvaluated() + "nodes");
        }

        /// <summary>
        /// create a maze and solve it.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int rows = 100;
            int cols = 100;
            Program prog = new Program(rows, cols);
            prog.CompareSolvers();
            Console.ReadKey();
        }
    }
}