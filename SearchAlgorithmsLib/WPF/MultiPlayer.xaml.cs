﻿using System;
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
        private string list;
        public MultiPlayer()
        {
            InitializeComponent();
            vm = new MultyPlayerVM();
            this.DataContext = vm;
            
            //צריך לראות איך לעשות את הרשימה שתאזין לשינויים במודל- וצריך שאיכשהו המודל כל כמה שניות ישלח הודעה לשרת בשביל הליסט
            //ואז לעדכן את הרשימה שמופיעה לנו
         /*   this.list = "";
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_list");
            binding.Source = this.list;
            // BindingOperations.SetBinding(OnTargetUpdated, MultiPlayer.listOfPlayers, binding);*/
            


            listOfPlayers();

        }

   /*         private void OnTargetUpdated(Object sender, DataTransferEventArgs args)
        {
            string result = vm.ListStart();
            JArray array = JArray.Parse(result);
            foreach (string element in array)
            {
                comboBox.Items.Add(element);
            }
        }*/


            //אולי צריך יהיה לעשות פה מודל ווי.אמ ואז זה יהיה צריך להיות במודל.
            // בנוסף- צריך לחשוב האם כדאי לעשות סוג של ליסנר כדי שאם משתמש פותח משחק חדש שהוא ישר יופיע לשחקן אחר
            //get the list from the server and shoe it
            private void listOfPlayers()
        {
            string result = vm.ListStart();
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
              WaitForConnection wfc = new WaitForConnection(vm.Name, client,this);
        }

        private void join_game(object sender, RoutedEventArgs e)
        {
            string selected = this.comboBox.SelectionBoxItem.ToString();
            vm.Name = selected;
            vm.SaveSettings();
            Client client = new Client();
            string json = vm.join(client);
            MPwindow wind = new MPwindow(vm.Name, client, json);
            this.Close();
            wind.ShowDialog();
        }
    }
}
