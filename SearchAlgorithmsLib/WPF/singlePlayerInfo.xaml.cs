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
    /// Interaction logic for singlePlayerInfo.xaml
    /// </summary>
    /// 
    //זה מחליף את החלון של סינגל פלייר- פה יש שימוש ביוזר קונטרול
    //אם נשתמש בזה-צריך לעשות דאטא ביינדינג לשם קורות ועמודות ואז לשלוח את זה כמו קודם
    public partial class singlePlayerInfo : Window
    {
        public singlePlayerInfo()
        {
            InitializeComponent();
            Information info = new Information();
            grid.Children.Add(info);
        }

        private void new_single_game(object sender, RoutedEventArgs e)
        {
            //show the maze window
            //SinglePlayerWindow sw = new SinglePlayerWindow(vm.Name, vm.Rows, vm.Colomns);
            //sw.ShowDialog();
        }
    }
}
