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
    /// Interaction logic for AreYouSureRestart.xaml
    /// </summary>
    public partial class AreYouSureRestart : Window
    {
        public AreYouSureRestart()
        {
            InitializeComponent();
        }

        private void clicked_yes(object sender, RoutedEventArgs e)
        {
            //restart = event??
        }

        private void clicked_no(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
