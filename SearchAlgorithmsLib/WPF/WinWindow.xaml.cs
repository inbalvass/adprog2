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
        private MPwindow multyWindow;
        string whatWindow;

        /// <summary>
        /// a constructor for single player winning window.
        /// </summary>
        /// <param name="SPwindow">the single player window.</param>
        public WinWindow(SinglePlayerWindow SPwindow)
        {
            InitializeComponent();
            this.SPwindow = SPwindow;
            this.whatWindow = "single";
        }

        /// <summary>
        /// a constructor for multy player winning window.
        /// </summary>
        /// <param name="SPwindow">the multy player window.</param>
        public WinWindow(MPwindow window)
        {
            InitializeComponent();
            this.multyWindow = window;
            this.whatWindow = "multy";
        }

        /// <summary>
        /// closing the appropriate windows and back to menu.
        /// </summary>
        private void Clicked_OK(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            if (this.whatWindow == "single")
            {
                this.SPwindow.Close();
            }
            else
            {
                this.multyWindow.Close();
            }
            mw.Show();
        }
    }
}
