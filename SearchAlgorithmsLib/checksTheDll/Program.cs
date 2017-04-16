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
        private Maze maze;
        //ctor
        public Program(int rows, int cols)
          {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            maze = mazeGenerate.Generate(rows, cols);
        }

        public void CompareSolvers( )
        {
            Console.WriteLine(maze.ToString());
            Adapter adp = new Adapter(maze);

            //need to solve with bfs and dfs
            Console.WriteLine("bfs");
            BFS<Position> bfs = new BFS<Position>();
            bfs.search(adp);
            //Console.WriteLine("the solution",bfs.backTrace(adp.getGoalState()));//חושבת שלא צריך להדפיס את זה
            Console.WriteLine("bfs open"+ bfs.getNumberOfNodesEvaluated()+ "nodes");

            Console.ReadKey();
            Console.WriteLine("dfs");
            DFS<Position> dfs = new DFS<Position>();
            dfs.search(adp);
            Console.WriteLine("dfs open"+ dfs.getNumberOfNodesEvaluated()+ "nodes");
        }

        public static void Main(string[] args)
        {
            int rows = 3;
            int cols = 3;
            Program prog = new Program(rows, cols);
            prog.CompareSolvers();
            Console.ReadKey();
        }
    }
}
