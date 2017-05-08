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
    /// Interaction logic for AreYouSureMenu.xaml
    /// </summary>
    public partial class AreYouSureMenu : Window
    {
        private SinglePlayerWindow singlePlayerWin;
        public AreYouSureMenu(SinglePlayerWindow singlePlayerWin)
        {
            InitializeComponent();
            this.singlePlayerWin = singlePlayerWin;
        }

        private void clicked_no(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clicked_yes(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            this.singlePlayerWin.Close();
            mw.Show();
        }
    }
}
