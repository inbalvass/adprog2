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

        // private string maze;
        // private int rows, cols;
        private double heightOfSqure, widthOfSqure;
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

            drawTheMaze(rows, cols, mazeStr);
        }

        private void drawTheMaze(int rows, int cols, string mazeStr)
        {
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            SolidColorBrush whiteBrush = new SolidColorBrush();
            whiteBrush.Color = Colors.White;

            widthOfSqure = myCanvas.Width / cols;
            heightOfSqure = myCanvas.Height / rows;
            int place;
            int i = 0, j = 0;
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < cols; j++)
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

            //draw the exit
            Image image = new Image();
            //image.Source = "pacman.jpg";
            //var uriSource = new Uri("exit.jpg", UriKind.Relative);
            //image.Source = new BitmapImage(uriSource);

            // image.Source = new BitmapImage(new Uri("images/image.png"));
            new BitmapImage(new Uri(@"/images/exit.jpg", UriKind.Relative));
            Canvas.SetLeft(image, j * widthOfSqure);
            Canvas.SetTop(image, i * heightOfSqure);
            myCanvas.Children.Add(image); 
        }

        public void moveTo(int curRow, int curCol, int row, int col)
        {
            int place = row * Cols + col;//**check if this is the right Cols
            if (mazeStr[place] == '0')
            {
                //drawing the player in place and wipes the earlier
                Image image = new Image();
                new BitmapImage(new Uri(@"/images/exit.jpg", UriKind.Relative));
                Canvas.SetLeft(image, col * widthOfSqure);
                Canvas.SetTop(image, row * heightOfSqure);
                myCanvas.Children.Add(image);

                Rectangle r = new Rectangle();
                r.Height = heightOfSqure;
                r.Width = widthOfSqure;
                SolidColorBrush whiteBrush = new SolidColorBrush();
                whiteBrush.Color = Colors.White;
                r.Fill = whiteBrush;
            }
            else return;
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
