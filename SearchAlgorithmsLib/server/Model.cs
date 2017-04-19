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
        private JArray availableGames;

        public Model(IController conl)
        {
            control = conl;
            singleNames = new Dictionary<string, Maze>();
            singleSolutions = new Dictionary<string, Solution<Position>>();
            multyNames = new Dictionary<string, Maze>();
            multySolutions = new Dictionary<string, Solution<Position>>();
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
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            Maze maze = mazeGenerate.Generate(rows, cols);
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


        public string StartMazeCommand(string name, int rows, int cols)
        {
            //create the maze
            Maze maze = Generate(name, rows, cols, multyNames, multySolutions);
            //add the name to the available games to join
            availableGames.Add(name);
            return maze.ToJSON();
        }

        public string ListCommand()
        {
            return availableGames.ToString();
        }

        public string JoinCommand(string name)
        {
            //לראות איך לעשות את זה נכון
            if (!availableGames.Contains(name))
            {
                return "wrong input-game not exist";
            }

            //צריך לוודא שיורש ממולטיפלייר ואז יש לו את הרשימה


            //פה יש בעיה כי אי אפשר לעשות שגג לקליינט אלא  אם נקבל אותו
            //והבעיה שצריך לשמור גם מילון לפי הקליינט אז עדיין שזה ישמר פה כן או לא?
            //אם שומרים בקונטרולר אז צריך מחלקה אבסטרקטית כדי שכולם ירשו את הרשימה הזו

            //go to the multigame class and set dictionary here that this is the game we play
            //remove the name from the list because the game is no longer available
            availableGames.Remove(name);
            return "ss";
        }

        public string PlayCommand(string move)
        {
            //צריך לוודא שיורש ממולטיפלייר
            return "ss";
        }
        public string CloseCommand(string name)
        {
            //צריך לוודא שיורש ממולטיפלייר
            return "ss";
        }
    }
}
