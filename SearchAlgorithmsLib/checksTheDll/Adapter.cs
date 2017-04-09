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

        public Adapter(Maze mazes)
        {
            maze = mazes;
        }

        /*החלק הזה הגיוני?????? 
         *
          *
          *
          * 
          * 
         */

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
                    //create the state using state-pool and add it to the list
                }
            }

            //left
            if (s.state.Col - 1 >= 0)//assuming we start from 0
            {
                if (maze[s.state.Row, s.state.Col - 1] == MazeLib.CellType.Free) //means the cell is free
                {
                    //create the state using state-pool and add it to the list
                }
            }             

            //up
            if (s.state.Row + 1 != maze.Rows)//assuming we start from 0
            {
                if (maze[s.state.Row + 1, s.state.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    //create the state using state-pool and add it to the list
                }
            }

            //down
            if (s.state.Row - 1 >= 0)// assuming we start from 0
            {
                if (maze[s.state.Row - 1, s.state.Col] == MazeLib.CellType.Free)  //means the cell is free
                {
                    //create the state using state-pool and add it to the list
                }
            }
            return succerssors;
        }

        //נראה לי שזה אמור להיות בפרוגם מה שמופיע אחר כך
        //ctor
        public Adapter(int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            maze = mazeGenerate.Generate(rows, cols);
        }
    }
}
