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
    /// Interaction logic for WinWindow.xaml
    /// </summary>
    public partial class WinWindow : Window
    {
        private SinglePlayerWindow SPwindow;
        public WinWindow(SinglePlayerWindow SPwindow)
        {
            InitializeComponent();
            this.SPwindow = SPwindow;
        }

        private void clicked_OK(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            this.SPwindow.Close();
            mw.Show();
        }
    }
}
