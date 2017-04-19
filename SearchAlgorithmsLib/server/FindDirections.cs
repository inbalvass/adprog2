using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using Newtonsoft.Json.Linq;

namespace server
{
    class FindDirections
    {
        public List<Direction> directions { get; }
        public FindDirections()
        {
            List<Direction> directions = new List<Direction>();

        }

        public void listOfDirections(Solution<Position> solution)
        {
            int rowI, colI, rowBefore, colBefor;
            for (int i = solution.solution.Count() - 1; i > 0; i--)
            {
                rowI = solution.solution[i].state.Row;
                colI = solution.solution[i].state.Col;
                rowBefore = solution.solution[i - 1].state.Row;
                colBefor = solution.solution[i - 1].state.Col;

                if ((rowI == rowBefore) && (colI == colBefor + 1))
                {
                    directions.Add(Direction.Right);
                }
                else if ((rowI == rowBefore) && (colI == colBefor - 1))
                {
                    directions.Add(Direction.Left);
                }
                else if ((rowI == rowBefore + 1) && (colI == colBefor))
                {
                    directions.Add(Direction.Down);
                }
                else if ((rowI + 1 == rowBefore) && (colI == colBefor - 1))
                {
                    directions.Add(Direction.Up);
                }
                else
                {
                    directions.Add(Direction.Unknown);
                }
            }
        }

        public string fromListToString()
        {

            return directions.ToString();
        }

        public string ToJson(string name,int evaluate)
        {
            JObject solveObj = new JObject();
            solveObj["Name"] = name;
            solveObj["Solution"] = this.fromListToString();
            solveObj["NodesEvaluated"] = evaluate;
            return solveObj.ToString();
        }
        
    }
}
