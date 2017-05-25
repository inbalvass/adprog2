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
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerViewModel vm;
        public SinglePlayer()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;
        }

        /// <summary>
        /// creating a new single player game
        /// </summary>
    private void new_single_game(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            //show the maze window
            SinglePlayerWindow sw = new SinglePlayerWindow(vm.Name,vm.Rows, vm.Colomns);
            this.Close();
            sw.ShowDialog();
        }
    }
}
