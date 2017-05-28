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

        /// <summary>
        /// constructor
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            vm = new SettingsViewModel();
            this.DataContext = vm;
        }

        /// <summary>
        /// save settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_settings(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            this.Close();
        }

        /// <summary>
        /// cancel the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_settings(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }
    }
}
