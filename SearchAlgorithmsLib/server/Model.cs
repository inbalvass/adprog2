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
    class Model : IModel
    {
        /*כמה דברים:
         * 1) האם זה המשתנים הפרטיים שהוא צריך להחזיק?
         * 2) צריך להכיל מילון אחד פרטי עם שם ומה המבוך כדי שיהיה אפשר למצוא אותו באדפטר
         *3) צריך להכיל מילון אחד או שתיים עם השם והפתרון . שתיים כי  צריך מילון לכל סוג פתרון??
         * האם צריך להיות גנרי או לא?
             */

        Dictionary<string, Maze> names;
        Dictionary<string, Solution<Position>> solutions;

        public Model()
        {
            names = new Dictionary<string, Maze>();
            solutions = new Dictionary<string, Solution<Position>>();
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
                    solutions.Add(name, sol);
                }
                else
                {
                    DFS<Position> dfs = new DFS<Position>();
                    sol = dfs.search(adapter);
                    solutions.Add(name, sol);
                }
            }
            return sol.ToJson;
        }






        public string StartMazeCommand(string name, int rows, int cols)
        {
            return "ss";
        }

        public string ListCommand()
        {
            return "ss";
        }

        public string JoinCommand(string name)
        {
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
