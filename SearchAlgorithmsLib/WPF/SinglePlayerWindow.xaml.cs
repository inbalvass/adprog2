using MazeLib;
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
using System.Windows.Shapes;


namespace WPF
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window

    {
        private SPWindowViewModel vm;
        private string name;
        private int rows, cols;
        private MazeBoard mazeBoard;

        public SinglePlayerWindow(string name, int row, int col)
        {
            
            InitializeComponent();
            vm = new SPWindowViewModel();
            this.DataContext = vm;

          //  this.SizeChanged += OnWindowSizeChanged;

            this.name = name;
            this.rows = row;
            this.cols = col;
            vm.generate(name, rows, cols);

   
            this.mazeBoard = new MazeBoard();
            //this.mazeBoard.myCanvas.Width = SPwindow.Width;
            //this.mazeBoard.myCanvas.Height = SPwindow.Height;
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);

        }

        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
          //  double newWindowHeight = e.NewSize.Height;
          //  this.mazeBoard.myCanvas.Width = e.NewSize.Width;
          //  this.mazeBoard.myCanvas.Height = e.NewSize.Height;
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
             //the title need to be bounded to the name that entered- אני לא בטוחה שכך אכן נראה data binding
            //mazeBoarder.Rows = rows;
            //mazeBoarder.Cols = cols;
            
           // stackPanel1.Children.Add(this.mazeBoard);


        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            AreYouSureRestart sure = new AreYouSureRestart();
            sure.ShowDialog();
        }

        private void clicked_solve(object sender, RoutedEventArgs e)
        {
            //*****maybe in different thread? ****
            string solution= vm.solve(name);
            //********
                        //צריך להעביר את השחקן להתחלה ואז פשוט להזיז אותו צעד צעד לפתרון.

        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Title = name;

            //this.mazeBoard.myCanvas.Width = SPwindow.Width;
            //this.mazeBoard.myCanvas.Height = canvas.Height;
            canvas.Children.Add(this.mazeBoard);
            
            
        }

        /// <summary>
        /// return to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clicked_menu(object sender, RoutedEventArgs e)
        {
            AreYouSureMenu sure = new AreYouSureMenu(this);
            sure.ShowDialog();
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
                    
                    indexInMaze = indexInMaze - mazeBoard.Rows;
                    break;
                case Key.Down:
                    row++;
                    
                    indexInMaze = indexInMaze + mazeBoard.Rows;
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
            if ((col >= mazeBoard.Cols) || (row >= mazeBoard.Rows)
                || (col < 0) || (row < 0))
            {
                return;
            }
            
            mazeBoard.moveTo(new Position(row,col), indexInMaze);
        }

        public void startPlay()
        {
            //for loop or two
            //event key press etc...
          //  this.mazeBoard.moveTo(i, j,...);
        }
    }
}
