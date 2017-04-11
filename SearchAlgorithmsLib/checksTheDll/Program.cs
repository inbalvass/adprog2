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
    class Program
    {
     /*   private Maze maze;
        //ctor
        public Program(int rows, int cols)
          {
              DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
              maze = mazeGenerate.Generate(rows, cols);
          }*/

        public static void CompareSolver(int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            Maze maze = mazeGenerate.Generate(rows, cols);
            Console.WriteLine(maze.ToString());
            Adapter adp = new Adapter(maze);

            //need to solve with bfs and dfs

            BFS<Position> bfs = new BFS<Position>();
            bfs.search(adp);
            Console.WriteLine("bfs open", bfs.getNumberOfNodesEvaluated(), "nodes");

            DFS<Position> dfs = new DFS<Position>();
            dfs.search(adp);
            Console.WriteLine("dfs open", dfs.getNumberOfNodesEvaluated(), "nodes");
        }
        public static void Main(string[] args)
        {
            int rows = 10;
            int cols = 10;
            CompareSolver(rows, cols);
        }
    }
}
