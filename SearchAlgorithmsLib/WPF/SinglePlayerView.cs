using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//שאלה לבדיקה: איך נעשה הקשר בין האקסמל לבין מה שפה??

namespace WPF
{
    class SinglePlayerView : Window
    {
        private SinglePlayerViewModel vm;
        public SinglePlayerView()
        {
            //InitializeComponent(); //?
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            //את זה לשנות- פה צריך להיות ההצגה של החלון הבא- כרגע זה חוזר לחלון הראשון
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
