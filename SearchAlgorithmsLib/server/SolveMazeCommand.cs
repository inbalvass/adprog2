using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib

namespace server
{
    class SolveMazeCommand : ICommand
    {
        private IModel model;
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
            Solution<Position> sol;
            if (algorithm == 0)
            {
                BFS<Position> bfs = new BFS<Position>();
                ISearchable<Position> adp = model.getAdapter(name);
                sol= bfs.search(adp); 

                //save the soilution in dictionary
            }
            else
            {
                DFS<Position> dfs = new DFS<Position>();
                ISearchable<Position> adp = model.getAdapter(name);
                sol = dfs.search(adp);

                //save the solution in dictionary
            }

            return sol.ToJSON();
        }
    }
}
