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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clicked_single(object sender, RoutedEventArgs e)
        {
            SinglePlayer s = new SinglePlayer();
            this.Close();
            s.ShowDialog();
        }

        private void clicked_multi(object sender, RoutedEventArgs e)
        {
            MultiPlayer m = new MultiPlayer();
            this.Close();
            m.ShowDialog();
        }

        private void clicked_settings(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            this.Close();
            s.ShowDialog();
        }
    }
}
