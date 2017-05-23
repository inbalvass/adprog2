﻿using System;
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
using System.Windows.Shapes;
using MazeLib;
using Newtonsoft.Json;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MPwindow.xaml
    /// </summary>
    public partial class MPwindow : Window
    {
        private Client myClient;
        private MPViewModel vm;
        private string name;
        private MazeBoard mazeBoard;
        private MazeBoard mazeBoardPlay;
        private int rows, cols;
       // public event PropertyChangedEventHandler PropertyChanged;
        public bool Win;

        public MPwindow(string name, Client client, string json)
        {
            InitializeComponent();
            this.myClient = client;
            vm = new MPViewModel(client);
            this.DataContext = vm;

          //  this.SizeChanged += OnWindowSizeChanged;

            this.name = name;
            vm.VM_mazeStr = json;

            //find the rows and colomns
            dynamic data = JsonConvert.DeserializeObject(json);
            string help = data["Rows"];
            this.rows = int.Parse(help);
            help = data["Cols"];
            this.cols = int.Parse(help);

            this.mazeBoard = new MazeBoard();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);

        //    this.PropertyChanged += WinPropertyChanged;

        }

    /*    private void WinPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           // WinWindow win = new WinWindow(this);
        }*/


        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            AreYouSureRestart sure = new AreYouSureRestart();
            sure.ShowDialog();
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Title = name;
            this.mazeBoardPlay = new MazeBoard();
            mazeBoardPlay.mazeStr = this.mazeBoard.mazeStr;
            this.canvas1.Children.Add(this.mazeBoard);
            this.canvas2.Children.Add(mazeBoardPlay);
        }

        /// <summary>
        /// return to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clicked_menu(object sender, RoutedEventArgs e)
        {
          //  AreYouSureMenu sure = new AreYouSureMenu(this);
            //sure.ShowDialog();
        }


        //צריך להיות משהו דומה בשביל להציג את הצד השני כלומר את החלון של היריב
        private void clicked_solve(object sender, RoutedEventArgs e)
        {
            // string solution = vm.solve(name);
            string solution = "0011";
            dynamic data = JsonConvert.DeserializeObject(solution);
            string solutionStr = data["Solution"];
            int col = mazeBoard.Pos.Col;
            int row = mazeBoard.Pos.Row;
            for (int i = 0; i < solutionStr.Length; i++)
            {
                switch (solutionStr[i])
                {
                    case '2': //up
                        row--;
                        break;
                    case '3': //down
                        row++;
                        break;
                    case '1': //right
                        col++;
                        break;
                    case '0': //left
                        col--;
                        break;
                    default:
                        return;
                }
            }
            mazeBoard.moveTo(new Position(row, col));
        }

        private void SPwindow_KeyDown(object sender, KeyEventArgs e)
        {
            int col = mazeBoard.Pos.Col;
            int row = mazeBoard.Pos.Row;
            int indexInMaze = mazeBoard.IndexInMaze;
            switch (e.Key)
            {
                case Key.Up:
                    row--;
                    indexInMaze = indexInMaze - mazeBoard.Cols;
                    break;
                case Key.Down:
                    row++;
                    indexInMaze = indexInMaze + mazeBoard.Cols;
                    break;
                case Key.Right:
                    col++;
                    indexInMaze++;
                    break;
                case Key.Left:
                    col--;
                    indexInMaze--;
                    break;
                default:
                    return;
            }

            //check if the next step is not out of range
            if ((col >= mazeBoard.Cols) || (row >= mazeBoard.Rows)
                || (col < 0) || (row < 0))
                return;
            //check if the next step is not an obstacle
            if (mazeBoard.Blocks[indexInMaze] == '1')
                return;
            //update the current index
            mazeBoard.IndexInMaze = indexInMaze;
            mazeBoard.moveTo(new Position(row, col));
        }

    }
}
