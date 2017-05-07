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
        public SinglePlayerWindow(string name)
        {
            InitializeComponent();
            Title = name; //the title his bounded to the name that entered
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {

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
            MainWindow mw = new MainWindow();
            this.Close();
            mw.ShowDialog();
        }


    }
}
