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

        public SinglePlayerWindow(string name, int row, int col)
        {
            InitializeComponent();
            vm = new SPWindowViewModel();
            this.DataContext = vm;

            this.name = name;
            this.rows = row;
            this.cols = col;

        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
            Title = name; //the title need to be bounded to the name that entered- אני לא בטוחה שכך אכן נראה data binding
            mazeBoarder.Rows = rows;
            mazeBoarder.Cols = cols;
            mazeBoarder.Maze = vm.generate(name, rows, cols);
        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            AreYouSureRestart sure = new AreYouSureRestart();
            sure.ShowDialog();
        }

        private void clicked_solve(object sender, RoutedEventArgs e)
        {

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
    }
}
