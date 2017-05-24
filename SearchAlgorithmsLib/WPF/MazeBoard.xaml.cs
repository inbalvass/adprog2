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
using MazeLib;
using System.ComponentModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        private string blocks;
        private int rows;
        private int cols;
        private Position pos;
        private Position startPos;
        private Position endPos;
        private double heightOfSqure, widthOfSqure;
        private int indexInMaze;
        private int initialIndexInMaze;

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

        public void ParseData(string maze)
        {
            //get the information from the json string
            dynamic data = JsonConvert.DeserializeObject(maze);
            this.Blocks = data["Maze"];
            string help = data["Rows"];
            this.Rows = int.Parse(help);
            help = data["Cols"];
            this.Cols = int.Parse(help);
            //get the start point
            dynamic data2 = data["Start"];
            help = data2["Row"];
            int startRow = int.Parse(help);
            help = data2["Col"];
            int startCols = int.Parse(help);
            this.StartPos = new Position(startRow, startCols);
            this.Pos = StartPos;
            //get the end point
            dynamic data3 = data["End"];
            help = data3["Row"];
            int endRow = int.Parse(help);
            help = data3["Col"];
            int endCols = int.Parse(help);
            this.EndPos = new Position(endRow, endCols);
        }
        public void DrawMaze(string maze)
        {
            ParseData(maze);
            drawTheMaze();
        }

        private void drawTheMaze()
        {
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            widthOfSqure = myCanvas.Width / Cols;
            heightOfSqure = myCanvas.Height / Rows;
            int counter = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Rectangle r = new Rectangle();
                    r.Height = heightOfSqure;
                    r.Width = widthOfSqure;
                    if (Blocks[counter] == '1')//wall
                    {
                        r.Fill = blackBrush;
                        Canvas.SetLeft(r, j * widthOfSqure);
                        Canvas.SetTop(r, i * heightOfSqure);
                        myCanvas.Children.Add(r);
                    }
                    //draw the player icon
                    if (i == StartPos.Row && j == StartPos.Col)
                    {
                        Image playerImage = new Image();
                        BitmapImage bitmap = new BitmapImage(new Uri("/images/pacman.png", UriKind.Relative));
                        playerImage.Source = bitmap;
                        playerImage.Height = heightOfSqure;
                        playerImage.Width = widthOfSqure;
                        Canvas.SetLeft(playerImage, StartPos.Col* widthOfSqure);
                        Canvas.SetTop(playerImage, StartPos.Row* heightOfSqure);
                        myCanvas.Children.Add(playerImage);
                        IndexInMaze = counter;
                        InitialIndexInMaze = counter;
                    }
                    counter++;
            }
        }

            //draw the exit icon
            Image exitImage = new Image();
            BitmapImage carBitmap = new BitmapImage(new Uri("/images/exit.jpg", UriKind.Relative));
            exitImage.Source = carBitmap;
            exitImage.Height = heightOfSqure;
            exitImage.Width = widthOfSqure;
            Canvas.SetLeft(exitImage, EndPos.Col * widthOfSqure);
            Canvas.SetTop(exitImage, EndPos.Row * heightOfSqure);
            myCanvas.Children.Add(exitImage);
        }

        public void moveTo(Position nextPos, int index)
        {
            //check if the next step is not an obstacle
            if (Blocks[index] == '1')
            {
                return;
            }

            //update the current index
            IndexInMaze = index;

            if (Pos.Col == nextPos.Col && Pos.Row == nextPos.Row)
                return;

            //drawing the player in place and wipes the earlier
            Image image = new Image();
            BitmapImage carBitmap = new BitmapImage(new Uri("/images/pacman.png", UriKind.Relative));
            image.Source = carBitmap;
            image.Height = heightOfSqure;
            image.Width = widthOfSqure;
            Canvas.SetLeft(image, nextPos.Col * widthOfSqure);
            Canvas.SetTop(image, nextPos.Row * heightOfSqure);
            myCanvas.Children.Add(image);

            Rectangle r = new Rectangle();
            r.Height = heightOfSqure;
            r.Width = widthOfSqure;
            SolidColorBrush whiteBrush = new SolidColorBrush();
            whiteBrush.Color = Colors.White;
            r.Fill = whiteBrush;
            Canvas.SetLeft(r, Pos.Col * widthOfSqure);
            Canvas.SetTop(r, Pos.Row * heightOfSqure);
            myCanvas.Children.Add(r);

            //update the current position of the player
            Pos = nextPos;
        }

        //public static readonly DependencyProperty MazeProperty =
        //    DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard), new
        //    PropertyMetadata("0,1"));

        public Position Pos
        {
            get
            {
                return pos;
        }

            set
            {
                pos = value;
            }
        }

        public int IndexInMaze
        {
            get
            {
                return indexInMaze;
            }

            set
        {
                indexInMaze = value;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public int Cols
        {
            get
        {
                return cols;
        }

            set
            {
                cols = value;
            }
        }

        public Position StartPos
        {
            get
            {
                return startPos;
            }

            set
            {
                startPos = value;
            }
        }

        public Position EndPos
        {
            get
            {
                return endPos;
            }

            set
            {
                endPos = value;
            }
        }

        public int InitialIndexInMaze
        {
            get
            {
                return initialIndexInMaze;
            }

            set
            {
                initialIndexInMaze = value;
            }
        }

        public string Blocks
        {
            get
            {
                return blocks;
            }

            set
            {
                blocks = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
