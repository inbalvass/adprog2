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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsViewModel vm;
        public Settings()
        {
            InitializeComponent();
            vm = new SettingsViewModel();
            this.DataContext = vm;
            //IP.SetValue(Properties.Settings.Default.IP);
            //<span class="skimlinks-unlinked">this.IP</span> = Properties.Settings.Default.IP;
            //IP.Text = vm.IP;
            //Port.Text = vm.Port.ToString();
            //DefCols.Text = vm.DefCols.ToString();
            //DefRows.Text = vm.DefRows.ToString();
            //DefAlgo.SelectedIndex = vm.DefAlgo;
        }

        private void save_settings(object sender, RoutedEventArgs e)
        {
            //vm.IP = IP.Text;
            //vm.Port = int.Parse(Port.Text);
            //vm.DefCols = int.Parse(DefCols.Text);
            //vm.DefRows = int.Parse(DefRows.Text);
            //vm.DefAlgo = DefAlgo.SelectedIndex;
           // < span class="skimlinks-unlinked">Properties.Settings.Default.Save</span>();
            vm.SaveSettings();
           // MainWindow win = (MainWindow)Application.Current.MainWindow;
            //win.Show();
            this.Close();
        }

        private void cancel_settings(object sender, RoutedEventArgs e)
        {
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
           // win.Show();
            this.Close();
        }
    }
}
