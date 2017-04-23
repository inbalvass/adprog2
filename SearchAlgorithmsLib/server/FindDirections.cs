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
    /// <summary>
    /// find the direction to gt the solution
    /// </summary>
    class FindDirections
    {
        /// <summary>
        /// list of the directions that represent the solution
        /// </summary>
        public List<Direction> directions { get; }
        /// <summary>
        /// constructor
        /// </summary>
        public FindDirections()
        {
            directions = new List<Direction>();
        }

        /// <summary>
        /// get the solution and create the directions it need to move to go;
        /// </summary>
        /// <param name="solution">the solution</param>
        public void listOfDirections(Solution<Position> solution)
        {
            int rowI, colI, rowAfter, colAfter;
            for (int i = solution.solution.Count() - 1; i > 0; i--)
            {
                rowI = solution.solution[i].state.Row;
                colI = solution.solution[i].state.Col;
                rowAfter = solution.solution[i - 1].state.Row;
                colAfter = solution.solution[i - 1].state.Col;

                if ((rowI == rowAfter) && (colI == colAfter + 1))
                {
                    directions.Add(Direction.Left);
                }
                else if ((rowI == rowAfter) && (colI == colAfter - 1))
                {
                    directions.Add(Direction.Right);
                }
                else if ((rowI == rowAfter + 1) && (colI == colAfter))
                {
                    directions.Add(Direction.Up);
                }
                else if ((rowI + 1 == rowAfter) && (colI == colAfter))
                {
                    directions.Add(Direction.Down);
                }
                else
                {
                    directions.Add(Direction.Unknown);
                }
            }
        }

        /// <summary>
        /// convert the list direction to the string representation and return it
        /// </summary>
        /// <returns></returns>
        public string fromListToString()
        {
            string ls ="";
            foreach (Direction d in directions)
            {
                if (d == Direction.Right)
                {
                    ls += "1";
                }
                else if (d == Direction.Left)
                {
                    ls += "0";
                }
                else if (d == Direction.Down)
                {
                    ls += "3";
                }
                else if (d == Direction.Up)
                {
                    ls += "2";
                }
                else
                {
                    //Direction.Unknown
                    ls += "-1";
                }
            }
            return ls;
        }

        /// <summary>
        /// create the json
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <param name="evaluate">the number of evaluated nodes</param>
        /// <returns></returns>
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
