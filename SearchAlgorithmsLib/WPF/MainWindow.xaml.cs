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

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// what to do when click to play single
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clicked_single(object sender, RoutedEventArgs e)
        {
            SinglePlayer s = new SinglePlayer();
            //singlePlayerInfo s = new singlePlayerInfo();
            this.Close();
            s.ShowDialog();
        }

        /// <summary>
        /// what to do when click to play multy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clicked_multi(object sender, RoutedEventArgs e)
        {
            MultiPlayer m = new MultiPlayer();
            this.Close();
            m.ShowDialog();
        }

        /// <summary>
        /// what to do when click to set settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clicked_settings(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            this.Hide();
            s.ShowDialog();
            this.Show();
        }
    }
}
