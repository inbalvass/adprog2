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
    public class Adapter : ISearchable<Position>
    {
        private Maze maze;

        public Adapter(Maze mazes)
        {
            maze = mazes;
        }

        public State<Position> getInitialState()
        {
            Position pos = maze.InitialPos;
            State<Position> state = State<Position>.StatePool.getInstance(pos);
            state.cost = 0;
            state.cameFrom = null;
            return state;
        }

        public State<Position> getGoalState()
        {
            Position pos = maze.GoalPos;
            return State<Position>.StatePool.getInstance(pos);
        }

        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            List<State<Position>> succerssors = new List<State<Position>>();

            //right
            if (s.state.Col+1 < maze.Cols)//assuming we start from 0
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

        /*private State<Position> hadToPoolString(State<Position> s,int row,int col)
        {
            Position pos = new Position(row, col);
            State<Position> current = new State<Position>(pos);
            if (!statePool.Contains(current))
            {
                current.cameFrom = s; //had new comeFrom
                                      //need to had also the cost

                statePool.Add(current);
                State<Position> st = statePool.Where(elem => current.Equals(elem)).First();
                return st;//  מחזיר רפרנס למה שכבר בתוך הרשימה
                
            }
            else
            {
                State<Position> st = statePool.Where(elem => current.Equals(elem)).First();
                st.cameFrom = s;
                                      //need to had also the cost
                return st;
            }
        }*/
    }
}
