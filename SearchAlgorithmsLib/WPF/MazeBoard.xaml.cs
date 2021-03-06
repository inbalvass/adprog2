﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

        /// <summary>
        /// constructor
        /// </summary>
        public MazeBoard()
        {
            InitializeComponent();
            myCanvas.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            myCanvas.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        /// <summary>
        /// load the user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e) { }
        
        /// <summary>
        /// get and set the maze for binding
        /// </summary>
        public string mazeStr
        {
            get { return (string)GetValue(mazeStrProperty); }
            set { SetValue(mazeStrProperty, value); }
        }

        /// <summary>
        /// create DependencyProperty for maze
        /// </summary>
        public static readonly DependencyProperty mazeStrProperty =
            DependencyProperty.Register("mazeStr", typeof(string), typeof(MazeBoard), new PropertyMetadata(string.Empty, Changed));

        /// <summary>
        /// the function to run when the maze has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as MazeBoard;
            c.DrawMaze((string)e.NewValue);
        }

        /// <summary>
        /// parse the information we get
        /// </summary>
        /// <param name="maze">the json we get</param>
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

        /// <summary>
        /// parse the information and draw the maze
        /// </summary>
        /// <param name="maze">the json that contains the information</param>
        public void DrawMaze(string maze)
        {
            ParseData(maze);
            DrawTheMaze();
        }

        /// <summary>
        /// draw the maze
        /// </summary>
        private void DrawTheMaze()
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

        /// <summary>
        /// move the player to the next point
        /// </summary>
        /// <param name="nextPos">nhe next posotion</param>
        /// <param name="index"> the current index</param>
        public void MoveTo(Position nextPos, int index)
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

        /// <summary>
        /// get and set the position
        /// </summary>
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

        /// <summary>
        /// get and set the index
        /// </summary>
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

        /// <summary>
        /// get and set the rows
        /// </summary>
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

        /// <summary>
        /// get and set the cols
        /// </summary>
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

        /// <summary>
        /// get and set the start position
        /// </summary>
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

        /// <summary>
        /// get and set the end position
        /// </summary>
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

        /// <summary>
        /// get and set the InitialIndexInMaze
        /// </summary>
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

        /// <summary>
        /// get and set the blocks
        /// </summary>
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

        /// <summary>
        /// create the event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// notipy somthing happend
        /// </summary>
        /// <param name="propName"></param>
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
