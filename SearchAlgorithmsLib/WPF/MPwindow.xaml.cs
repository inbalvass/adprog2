﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;

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
        public bool Win;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="json"></param>
        public MPwindow(string name, Client client, string json)
        {
            InitializeComponent();
            this.myClient = client;
            vm = new MPViewModel(client);
            this.DataContext = vm;

            this.name = name;
            vm.VM_mazeStr = json;

            this.mazeBoard = new MazeBoard();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);

            myClient.PlayerMoved += Multy_PlayerMoved;
            Closing += OnWindowClosing;
        }

        /// <summary>
        /// what to do when close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void OnWindowClosing(object sender, CancelEventArgs e)
        {
            vm.Close(name);
            Thread.Sleep(100);
        }

        /// <summary>
        /// load the maze board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MzeBoard_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// load the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Loaded(object sender, RoutedEventArgs e)
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
        private void Clicked_menu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to go back to menu?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mw = new MainWindow();
                //close the connection
                vm.Close(name);
                Thread.Sleep(100);
                this.Close();
                mw.Show();
            }
        }

        /// <summary>
        /// move the oter player according what the server send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Multy_PlayerMoved(object sender, PlayerMovedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                int indexInMaze = mazeBoardPlay.IndexInMaze;
                Direction direction = e.Direction;
                int col = mazeBoardPlay.Pos.Col;
                int row = mazeBoardPlay.Pos.Row;
                if (direction == Direction.Up) {
                    row--;
                    indexInMaze = indexInMaze - mazeBoardPlay.Cols;
                }
                else if (direction == Direction.Down) {
                    row++;
                    indexInMaze = indexInMaze + mazeBoardPlay.Cols;
                }
                else if (direction == Direction.Right) {
                    col++;
                    indexInMaze++;
                }
                else if (direction == Direction.Left) {
                    col--;
                    indexInMaze--;
                }
                else
                {
                    ConnectionClosed closed = new ConnectionClosed();
                    this.Close();
                    closed.ShowDialog();
                }
                if ((col < mazeBoard.Cols) && (row < mazeBoard.Rows) && (col >= 0) && (row >= 0))
                {
                    mazeBoardPlay.MoveTo(new Position(row, col), indexInMaze);
                }
                //check if the player won
                //CheckIfWin();
            });
        }

        /// <summary>
        /// what to do when keyboard pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MPwindow_KeyDown(object sender, KeyEventArgs e)
        {
            int col = mazeBoard.Pos.Col;
            int row = mazeBoard.Pos.Row;
            int indexInMaze = mazeBoard.IndexInMaze;
            string move;
            switch (e.Key)
            {
                case Key.Up:
                    row--;
                    indexInMaze = indexInMaze - mazeBoard.Cols;
                    move = "up";
                    break;
                case Key.Down:
                    row++;
                    indexInMaze = indexInMaze + mazeBoard.Cols;
                    move = "down";
                    break;
                case Key.Right:
                    col++;
                    indexInMaze++;
                    move = "right";
                    break;
                case Key.Left:
                    col--;
                    indexInMaze--;
                    move = "left";
                    break;
                default:
                    return;
            }

            //check if the next step is not out of range
            if ((col >= mazeBoard.Cols) || (row >= mazeBoard.Rows)
                || (col < 0) || (row < 0))
                return;

            mazeBoard.MoveTo(new Position(row, col), indexInMaze);
            vm.Play(move);
            CheckIfWin();
        }

        /// <summary>
        /// check if the player won
        /// </summary>
        public void CheckIfWin()
        {
            if ((mazeBoard.Pos.Col == mazeBoard.EndPos.Col) && (mazeBoard.Pos.Row == mazeBoard.EndPos.Row))
            {
                WinWindow win = new WinWindow(this);
                win.ShowDialog();
            }
        }
    }
}
