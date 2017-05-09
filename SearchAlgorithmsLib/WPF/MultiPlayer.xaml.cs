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
        public MultiPlayer()
        {
            InitializeComponent();
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
        }

        private void join_game(object sender, RoutedEventArgs e)
        {

        }
    }
}
