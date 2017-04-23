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
        /// this function returns the initial state of the maze.
        /// </summary>
        /// <returns> the initial state.
        /// </returns>
        public State<Position> getInitialState()
        {
            Position pos = maze.InitialPos;
            State<Position> state = State<Position>.StatePool.getInstance(pos);
            state.cost = 0;
            state.cameFrom = null;
            return state;
        }

        /// <summary>
        /// this function returns the goal state of the maze.
        /// </summary>
        /// <returns> the goal state.
        /// </returns>
        public State<Position> getGoalState()
        {
            Position pos = maze.GoalPos;
            return State<Position>.StatePool.getInstance(pos);
        }

        /// <summary>
        /// this function calculates a list of all the possible states to go to,
        /// from a specific state.
        /// </summary>
        /// <param name="s"> the state
        /// </param>
        /// <returns> the list of thates
        /// </returns>
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            List<State<Position>> succerssors = new List<State<Position>>();

            //right
            if (s.state.Col + 1 < maze.Cols)//assuming we start from 0
            {
                if (maze[s.state.Row, s.state.Col + 1] == MazeLib.CellType.Free)
                // &&(s.state.Row != maze.InitialPos.Row && s.state.Col + 1 != maze.InitialPos.Col)) //means the cell is free
                {
                    Position pos = new Position(s.state.Row, s.state.Col + 1);
                    //create or get the state using state-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.getInstance(pos);

                    son.cameFrom = s;
                    son.cost = s.cost + 1;
                    succerssors.Add(son);
                }
            }

            //left
            if (s.state.Col - 1 >= 0)//assuming we start from 0
            {
                if (maze[s.state.Row, s.state.Col - 1] == MazeLib.CellType.Free) //means the cell is free
                {
                    Position pos = new Position(s.state.Row, s.state.Col - 1);
                    //create or get the state using state-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.getInstance(pos);
                    son.cameFrom = s;
                    son.cost = s.cost + 1;
                    succerssors.Add(son);
                }
            }

            //up
            if (s.state.Row + 1 < maze.Rows)//assuming we start from 0
            {
                if (maze[s.state.Row + 1, s.state.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    Position pos = new Position(s.state.Row + 1, s.state.Col);
                    //create or get the state using state-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.getInstance(pos);
                    son.cameFrom = s;
                    son.cost = s.cost + 1;
                    succerssors.Add(son);
                }
            }

            //down
            if (s.state.Row - 1 >= 0)// assuming we start from 0
            {
                if (maze[s.state.Row - 1, s.state.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    Position pos = new Position(s.state.Row - 1, s.state.Col);
                    //create or get the state using state-pool and add it to the list
                    State<Position> son = State<Position>.StatePool.getInstance(pos);
                    son.cameFrom = s;
                    son.cost = s.cost + 1;
                    succerssors.Add(son);
                }
            }
            return succerssors;
        }
    }
}