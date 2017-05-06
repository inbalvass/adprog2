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
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerViewModel vm;
        public SinglePlayer()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;

            Name.Text = vm.Name;
            rows.Text = vm.Rows.ToString();
            colomns.Text = vm.Colomns.ToString();
        }

        private void new_single_game(object sender, RoutedEventArgs e)
        {
            //create a new maze and draw it 

            vm.Name = Name.Text;
            vm.Rows = int.Parse(rows.Text);
            vm.Colomns = int.Parse(colomns.Text);


            // < span class="skimlinks-unlinked">Properties.Settings.Default.Save</span>();
            vm.SaveSettings();
            //את זה לשנות- פה צריך להיות ההצגה של החלון הבא- כרגע זה חוזר לחלון הראשון
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
