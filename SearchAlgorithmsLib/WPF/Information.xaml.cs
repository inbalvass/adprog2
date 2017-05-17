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
    /// Interaction logic for Information.xaml
    /// </summary>
    /// 
    //יוזר קונטרול לחלק של הטופס- לחשוב האם להשתמש בזה כי זה גורר שינויים והרבה בסינגל 
    public partial class Information : UserControl
    {
        private SinglePlayerViewModel vm;
        public Information()
        {
            //InitializeComponent();
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;
        }
    }
}
