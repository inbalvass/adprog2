using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        public MazeBoard()
        {
            InitializeComponent();
            myCanvas.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            myCanvas.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }


        public string mazeStr
        {
            get { return (string)GetValue(mazeStrProperty); }
            set { SetValue(mazeStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for mazeStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty mazeStrProperty =
            DependencyProperty.Register("mazeStr", typeof(string), typeof(MazeBoard), new PropertyMetadata(string.Empty, Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as MazeBoard;
            c.DrawMaze((string)e.NewValue);
        }

        public void DrawMaze(string maze)
        {
            //get the information from the json string
            dynamic data = JsonConvert.DeserializeObject(maze);
            string mazeStr = data["Maze"];
            string help = data["Rows"];
            int rows = int.Parse(help);
            help = data["Cols"];
            int cols = int.Parse(help);
            //get the start point
            dynamic data2 = data["Start"];
            help = data2["Row"];
            int startRow = int.Parse(help);
            help = data2["Col"];
            int startCols= int.Parse(help);
            //get the end point
            dynamic data3 = data["End"];
            help = data3["Row"];
            int endRow = int.Parse(help);
            help = data3["Col"];
            int endCols = int.Parse(help);

            drowTheMaze(mazeStr, rows, cols);



        }

        private void drowTheMaze(string mazeStr,int rows,int cols)
        {
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            SolidColorBrush whiteBrush = new SolidColorBrush();
            whiteBrush.Color = Colors.White;

            double widthOfSqure = myCanvas.Width / cols;
            double heightOfSqure = myCanvas.Height / rows;
            int place;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Rectangle r = new Rectangle();
                    r.Height = heightOfSqure;
                    r.Width = widthOfSqure;
                    place = i * cols + j; //the index in the string
                    if (mazeStr[place] == '0')
                    {
                        r.Fill = whiteBrush;
                    }
                    else
                    {
                        r.Fill = blackBrush;
                    }
                    Canvas.SetLeft(r, j * widthOfSqure);
                    Canvas.SetTop(r, i * heightOfSqure);
                    myCanvas.Children.Add(r);
                }
            }
        }





        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,binding, etc...

            //נראה לי שאת כל זה אפשר בכלל למחוק...
        public static readonly DependencyProperty RowsProperty =
         DependencyProperty.Register("Rows", typeof(int), typeof(MazeBoard), new
        PropertyMetadata(0));

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public static readonly DependencyProperty ColsProperty =
         DependencyProperty.Register("Cols", typeof(int), typeof(MazeBoard), new
        PropertyMetadata(0));

        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }


        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard), new
            PropertyMetadata("0,1"));

        public string Maze
        {
            get { return (string)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }


        public static readonly DependencyProperty InitialPosProperty =
            DependencyProperty.Register("InitialPos", typeof(string), typeof(MazeBoard), new
            PropertyMetadata("0,1"));

        public string InitialPos
        {
            get { return (string)GetValue(InitialPosProperty); }
            set { SetValue(InitialPosProperty, value); }
        }

        public static readonly DependencyProperty GoalPosProperty =
            DependencyProperty.Register("GoalPos", typeof(string), typeof(MazeBoard), new
            PropertyMetadata("0,1"));

        public string GoalPos
        {
            get { return (string)GetValue(GoalPosProperty); }
            set { SetValue(GoalPosProperty, value); }
        }
    }
}
