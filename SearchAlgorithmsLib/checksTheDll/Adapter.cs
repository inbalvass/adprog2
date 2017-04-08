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
