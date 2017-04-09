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

        private State<Position> hadToPoolString(State<Position> s)
        {
            Position pos = new Position(s.state.Row, s.state.Col + 1);
            State<Position> current = new State<Position>(pos);
            if (!statePool.Contains(current))
            {
                current.cameFrom = s; //had new comeFrom
                                      //need to had also the cost

                statePool.Add(current);
                return current;//אולי נחזיר פה רפרנס שלו או שצריך להחזיר רפרנס למה שכבר בתוך הרשימה..
                
            }
            else
            {
                //איך למצוא ולעדכן מה שנמצא פה?
                //יש עם זה בעיה לפי האינטרנט לעשות את זה. כנראה נצטרך במקום זה לעבוד עם מילון שהמפתח שלו יהיה
                //ההאש של הסטייט ואז זה יפתר
                //כרגע עשיתי שהוא מוחק ומכניס מחדש...
                current.cameFrom = s; //had new comeFrom
                                      //need to had also the cost
                statePool.Remove(s);
                statePool.Add(s);
                return current;
            }

        }

        //נראה לי שזה אמור להיות בפרוגם מה שמופיע אחר כך
        //ctor
      /*  public Adapter(int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            maze = mazeGenerate.Generate(rows, cols);
        }*/
    }
}
