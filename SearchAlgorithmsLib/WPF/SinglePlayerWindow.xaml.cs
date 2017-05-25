using MazeLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPF
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    /// 
    public partial class SinglePlayerWindow : Window

    {
        private SPWindowViewModel vm;
        private string name;
        private int rows, cols;
        private MazeBoard mazeBoard;

        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="name"> the name of the maze</param>
        /// <param name="row"> the number of rows</param>
        /// <param name="col"> the number of columns</param>
        public SinglePlayerWindow(string name, int row, int col)
        {
            
            InitializeComponent();
            vm = new SPWindowViewModel();
            this.DataContext = vm;
            this.name = name;
            this.rows = row;
            this.cols = col;
            vm.generate(name, rows, cols);
            this.mazeBoard = new MazeBoard();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// handle the player's request to restart the game.
        /// </summary>
        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to restart?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                mazeBoard.moveTo(mazeBoard.StartPos, mazeBoard.InitialIndexInMaze);
            }
        }

        /// <summary>
        /// handle the player's request to solve the game.
        /// </summary>
        private async void clicked_solve(object sender, RoutedEventArgs e)
        {
            //locating the player in the start position 
            mazeBoard.moveTo(mazeBoard.StartPos, mazeBoard.InitialIndexInMaze);

            string solution = vm.solve(name);
            dynamic data = JsonConvert.DeserializeObject(solution);
            string solutionStr = data["Solution"];
            int col = mazeBoard.Pos.Col;
            int row = mazeBoard.Pos.Row;

            for (int i = 0; i < solutionStr.Length; i++)
            {
                switch (solutionStr[i])
                {
                    case '2':
                        row--;
                        break;
                    case '3':
                        row++;
                        break;
                    case '1':
                        col++;
                        break;
                    case '0':
                        col--;
                        break;
                    default:
                        return;
                }
                //waiting for the task to finish drawing
                await Task.Delay(200);
                //drawing the next step
                mazeBoard.moveTo(new Position(row, col), mazeBoard.InitialIndexInMaze);
                //check if the player won
                CheckIfWin();
            }
        }

        /// <summary>
        /// adding the mazeBoard to the canvas at load time.
        /// </summary>
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Title = name;
            canvas.Children.Add(this.mazeBoard);
        }

        /// <summary>
        /// return to the main window
        /// </summary>
        private void clicked_menu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to go back to menu?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();
            }
        }

        /// <summary>
        /// handle the event of pressing the direction keys on keyboard.
        /// </summary>
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
            
            //move the player
            mazeBoard.moveTo(new Position(row,col), indexInMaze);
            //check if the player won
            CheckIfWin();
        }

        /// <summary>
        /// check if the player won the game and handle.
        /// </summary>
        public void CheckIfWin()
        {
            if((mazeBoard.Pos.Col == mazeBoard.EndPos.Col) && (mazeBoard.Pos.Row == mazeBoard.EndPos.Row))
            {
                WinWindow win = new WinWindow(this);
                win.ShowDialog();
            }
        }
    }
}
