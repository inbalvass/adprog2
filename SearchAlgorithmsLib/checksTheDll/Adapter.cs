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
    /*
     * אני לא סגורה שזה באמת מה שאמורים לעשות פה.....
     * */
    public class Adapter : ISearchable<Position>
    {
        private Maze maze;
        private HashSet<State<Position>> statePool;

        public Adapter(Maze mazes)
        {
            maze = mazes;
            statePool = new HashSet<State<Position>>();
        }

        public State<Position> getInitialState()
        {
            Position pos = maze.InitialPos;
            State<Position> state = new State<Position>(pos);
            return state;
        }

        public State<Position> getGoalState()
        {
            Position pos = maze.GoalPos;
            State<Position> state = new State<Position>(pos);
            return state;
        }

        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            //צריך לקבל את הכיוון של המבוך ולפי זה לבחור לאיזה בנים אפשר ללכת??
            List<State<Position>> succerssors = new List<State<Position>>();
            

            //right
            if (s.state.Col+1 != maze.Cols)//assuming we start from 0
            {
                if (maze[s.state.Row, s.state.Col + 1] == MazeLib.CellType.Free) //means the cell is free
                {
                    State<Position> sun = hadToPoolString(s, s.state.Row, s.state.Col + 1);
                    succerssors.Add(sun);
                }
            }

            //left
            if (s.state.Col - 1 >= 0)//assuming we start from 0
            {
                if (maze[s.state.Row, s.state.Col - 1] == MazeLib.CellType.Free) //means the cell is free
                {
                    State<Position> sun = hadToPoolString(s, s.state.Row, s.state.Col - 1);
                    succerssors.Add(sun);
                    //create the state using state-pool and add it to the list
                }
            }             

            //up
            if (s.state.Row + 1 != maze.Rows)//assuming we start from 0
            {
                if (maze[s.state.Row + 1, s.state.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    State<Position> sun = hadToPoolString(s, s.state.Row + 1, s.state.Col);
                    succerssors.Add(sun);
                    //create the state using state-pool and add it to the list
                }
            }

            //down
            if (s.state.Row - 1 >= 0)// assuming we start from 0
            {
                if (maze[s.state.Row - 1, s.state.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    //create the state using state-pool and add it to the list
                    State<Position> sun = hadToPoolString(s, s.state.Row - 1, s.state.Col);
                    succerssors.Add(sun);
                }
            }
            return succerssors;
        }

        private State<Position> hadToPoolString(State<Position> s,int row,int col)
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
        }
    }
}
