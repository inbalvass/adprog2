using System;
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
        public event PropertyChangedEventHandler PropertyChanged;
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

            this.mazeBoard = new MazeBoard();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);

            myClient.PlayerMoved += multy_PlayerMoved;

            Closing += OnWindowClosing;

        }

        internal void OnWindowClosing(object sender, CancelEventArgs e)
        {
            vm.close(name);
        }

        /* private void WinPropertyChanged(object sender, PropertyChangedEventArgs e)
         {
             WinWindow win = new WinWindow(this);
         }*/


        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to restart?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                mazeBoard.moveTo(mazeBoard.StartPos, mazeBoard.InitialIndexInMaze);
            }
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
            MessageBoxResult result = MessageBox.Show("Are you sure you want to go back to menu?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();

                //close the connection
                vm.close(name);
            }
        }



        //צריך להיות משהו דומה בשביל להציג את הצד השני כלומר את החלון של היריב
        //להוסיף בדיקה האם יש ניצחון גם פה מצד השחקן השני ואז לעשות חלון הפסד וגם בתזוזה ואז לעשות חלון ניצחון!
        private void multy_PlayerMoved(object sender, PlayerMovedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Direction direction = e.Direction;
                int col = mazeBoardPlay.Pos.Col;
                int row = mazeBoardPlay.Pos.Row;
                if (direction == Direction.Up) { row--; }
                else if (direction == Direction.Down) { row++; }
                else if (direction == Direction.Right) { col++; }
                else if (direction == Direction.Left) { col--; }
                else { return; }
                mazeBoardPlay.moveTo(new Position(row, col), mazeBoardPlay.InitialIndexInMaze);
                //waiting for the task to finish drawing
                //await Task.Delay(200);
                //check if the player won
                CheckIfWin();
            });
        }

        /*  private async void clicked_solve(object sender, RoutedEventArgs e)
          {
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
                  mazeBoard.moveTo(new Position(row, col), mazeBoard.InitialIndexInMaze);
                  //check if the player won
                  CheckIfWin();
              }
          }*/

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

            mazeBoard.moveTo(new Position(row, col), indexInMaze);
            vm.play(move);
            CheckIfWin();
        }
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
