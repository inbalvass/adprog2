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
    /// Interaction logic for ConnectionClosed.xaml
    /// </summary>
    public partial class ConnectionClosed : Window
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ConnectionClosed()
        {
            InitializeComponent();
        }

        /// <summary>
        /// what to do when ok is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clicked_OK(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
