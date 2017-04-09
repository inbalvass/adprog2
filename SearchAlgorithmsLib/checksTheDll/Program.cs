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

        public void CompareSolver(int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            Maze maze = mazeGenerate.Generate(rows, cols);
            Console.WriteLine(maze.ToString());
            Adapter adp = new Adapter(maze);

            //need to solve with bfs and dfs

        }
        static void Main(string[] args)
        {
            
        }
    }
}
