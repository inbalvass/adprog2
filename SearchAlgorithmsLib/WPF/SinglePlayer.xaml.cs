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
        }

    private void new_single_game(object sender, RoutedEventArgs e)
        {
            //create a new maze and draw it 

            // < span class="skimlinks-unlinked">Properties.Settings.Default.Save</span>();
            vm.SaveSettings();
            //אחרי ששומרים את הפרטים צריך לשלוח פקודה ליצירת המבוך החדש
            // זה צריך להיות בוי.אמ ואז במודל ושם צריך להיות פקודה דרך סוקט נפרד לשלוח את הפרטים וליצור מבוך
            //ואז צריך להיות ההצגה של המבוך עצמו

            //show the maze window
            SinglePlayerWindow sw = new SinglePlayerWindow();
            this.Close();
            sw.ShowDialog();
        }
    }
}
