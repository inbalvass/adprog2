using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace server
{
    class Model<T> : IModel
    {
        /*כמה דברים:
         * 1) האם זה המשתנים הפרטיים שהוא צריך להחזיק?
         * 2) צריך להכיל מילון אחד פרטי עם שם ומה המבוך כדי שיהיה אפשר למצוא אותו באדפטר
         *3) צריך להכיל מילון אחד או שתיים עם השם והפתרון . שתיים כי כנראה צריך מילון לכל סוג פתרון
         */

        private Maze maze;
        private ISearchable<Position> adapter;

        public ISearchable<Position> getAdapter(string name)
        {
            //לא נכון
            //need to find the maze in a dictionary.
            //so need to save a maze in dictionary after created
            Maze maze = new Maze();


            adapter = new Adapter(maze);
            return adapter;
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            maze = mazeGenerate.Generate(rows, cols);
            //צריך לשמור פה את המבוך והשם במילון
            return maze;
        }
    }
}
