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
       // private MPwindow multyWindow;
        public ConnectionClosed()
        {
            InitializeComponent();
           // this.multyWindow = window;
        }

        private void clicked_OK(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
         //   this.multyWindow.Close();
            mw.Show();
        }
    }
}
