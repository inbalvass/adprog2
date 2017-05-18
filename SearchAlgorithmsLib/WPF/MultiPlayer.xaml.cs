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

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;



namespace WPF
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private MultyPlayerVM vm;
        public MultiPlayer()
        {
            InitializeComponent();
            vm = new MultyPlayerVM();
            this.DataContext = vm;
            listOfPlayers();

        }



    //אולי צריך יהיה לעשות פה מודל ווי.אמ ואז זה יהיה צריך להיות במודל.
    // בנוסף- צריך לחשוב האם כדאי לעשות סוג של ליסנר כדי שאם משתמש פותח משחק חדש שהוא ישר יופיע לשחקן אחר
    //get the list from the server and shoe it
    private void listOfPlayers()
        {
            Client myClient = new Client();
            string command = "list";
            string result= myClient.StartSingle(command);
            JArray array = JArray.Parse(result);
            foreach (string element in array)
            {
                comboBox.Items.Add(element);
            }
        }
        

        private void new_multi_game(object sender, RoutedEventArgs e)
        {

            //יוזר קונטרול??
            //כרגע פותח את החלון של הסינגל פלייר
            //צריך לשנות שפה ישלח בקשה ועד שהוא לא מקבל לא פותח חלון
            vm.SaveSettings();
            Client client = new Client();
            vm.start(client);
            //show the maze window

            //נעשה חלון חכה לחיבור והוא יבדוק מתי מגיעה לו תוצאה

            WaitForConnection wfc = new WaitForConnection();
            wfc.client = client;
          //  SinglePlayerWindow sw = new SinglePlayerWindow(vm.Name, vm.Rows, vm.Colomns);
           this.Close();
            wfc.ShowDialog();
        }

        private void join_game(object sender, RoutedEventArgs e)
        {
            //צריך לגרום לו לפתוח חלון
        }
    }
}
