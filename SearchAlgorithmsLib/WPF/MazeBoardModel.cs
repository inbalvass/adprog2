using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class MazeBoardModel
    {

        public string mazeStr
        {
            get;
            set;
        }
        public void DrawMaze(string maze)
        {
            //Array a = solution.ToArray<char>();
            //Rectangle rec = new Rectangle { Width = 20, Height = 20 };
            //int x = 0, y = 0; //initialized to the starting point of the window?!?

            //for (int i = 0; i < solution.Length; i++)
            //{
            //    //the location of the rectangle
            //    Canvas.SetTop(rec, x);
            //    Canvas.SetLeft(rec, y);
            //    if (solution[i] == '1')
            //        rec.Fill = Brushes.Black;
            //    else
            //        rec.Fill = Brushes.White;
            //    mazeBoarder.myCanvas.Children.Add(rec);
            //    x++;
            //    y++;
        }
    }
}

