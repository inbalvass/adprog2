using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeGeneratorLib;
using MazeLib;


namespace checksTheDll
{
    /// <summary>
    /// This class's part is to adapt the maze object to Searchable,
    /// using object adapter pattern.
    /// </summary>
    public class Adapter : ISearchable<Position>
    {
        /// <summary>
        /// the adaptee maze
        /// </summary>
        private Maze maze;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="mazes"> the maze object.
        /// </param>
        public Adapter(Maze mazes)
        {
            maze = mazes;
        }

        /// <summary>
        /// this function returns the initial State of the maze.
        /// </summary>
        /// <returns> the initial State.
        /// </returns>
        public State<Position> GetInitialState()
        {
            Position pos = maze.InitialPos;
            State<Position> State = State<Position>.StatePool.GetInstance(pos);
            State.Cost = 0;
            State.CameFrom = null;
            return State;
        }

        /// <summary>
        /// this function returns the goal State of the maze.
        /// </summary>
        /// <returns> the goal State.
        /// </returns>
        public State<Position> GetGoalState()
        {
            Position pos = maze.GoalPos;
            return State<Position>.StatePool.GetInstance(pos);
        }

        /// <summary>
        /// this function calculates a list of all the possible States to go to,
        /// from a specific State.
        /// </summary>
        /// <param name="s"> the State
        /// </param>
        /// <returns> the list of thates
        /// </returns>
        public List<State<Position>> GetAllPossibleStates(State<Position> s)
        {
            List<State<Position>> succerssors = new List<State<Position>>();

            //right
            if (s.MyState.Col + 1 < maze.Cols)//assuming we start from 0
            {
                if (maze[s.MyState.Row, s.MyState.Col + 1] == MazeLib.CellType.Free)
                // &&(s.State.Row != maze.InitialPos.Row && s.State.Col + 1 != maze.InitialPos.Col)) //means the cell is free
                {
                    Position pos = new Position(s.MyState.Row, s.MyState.Col + 1);
                    //create or get the State using State-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.GetInstance(pos);

                    son.CameFrom = s;
                    son.Cost = s.Cost + 1;
                    succerssors.Add(son);
                }
            }

            //left
            if (s.MyState.Col - 1 >= 0)//assuming we start from 0
            {
                if (maze[s.MyState.Row, s.MyState.Col - 1] == MazeLib.CellType.Free) //means the cell is free
                {
                    Position pos = new Position(s.MyState.Row, s.MyState.Col - 1);
                    //create or get the State using State-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.GetInstance(pos);
                    son.CameFrom = s;
                    son.Cost = s.Cost + 1;
                    succerssors.Add(son);
                }
            }

            //up
            if (s.MyState.Row + 1 < maze.Rows)//assuming we start from 0
            {
                if (maze[s.MyState.Row + 1, s.MyState.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    Position pos = new Position(s.MyState.Row + 1, s.MyState.Col);
                    //create or get the State using State-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.GetInstance(pos);
                    son.CameFrom = s;
                    son.Cost = s.Cost + 1;
                    succerssors.Add(son);
                }
            }

            //down
            if (s.MyState.Row - 1 >= 0)// assuming we start from 0
            {
                if (maze[s.MyState.Row - 1, s.MyState.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    Position pos = new Position(s.MyState.Row - 1, s.MyState.Col);
                    //create or get the State using State-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.GetInstance(pos);
                    son.CameFrom = s;
                    son.Cost = s.Cost + 1;
                    succerssors.Add(son);
                }
            }
            return succerssors;
        }
    }
}