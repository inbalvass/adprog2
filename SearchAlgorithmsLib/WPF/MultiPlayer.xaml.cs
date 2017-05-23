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
using System.Collections.ObjectModel;

namespace WPF
{
    //כל מה שקשור לליסט פה בוויאו מודל ובמודל אפשר למחוק- כבר לר רלוונטי
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private MultyPlayerVM vm;
        private ObservableCollection<List_item> lists = new ObservableCollection<List_item>();
        public MultiPlayer()
        {
            InitializeComponent();
            vm = new MultyPlayerVM();
            this.DataContext = vm;

            comboBox.ItemsSource = lists;
            comboBox.DisplayMemberPath = "Name";

        } 

        private void new_multi_game(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            Client client = new Client();
            vm.start(client);
            //show the maze window
              WaitForConnection wfc = new WaitForConnection(vm.Name, client,this);
        }

        private void join_game(object sender, RoutedEventArgs e)
        {
            int index = comboBox.SelectedIndex;
            string selected = lists[index].Name;
            if (selected == "wrong index")
            {
                Label l = new Label();
                l.Content = "somthing wrong- please choose again";
                canvas.Children.Add(l);
            }else
            {
                vm.Name = selected;
                vm.SaveSettings();
                Client client = new Client();
                string json = vm.join(client);
                MPwindow wind = new MPwindow(vm.Name, client, json);
                this.Close();
                wind.ShowDialog();

            }
        }

        private void comboBox_DropDownOpened(object sender, EventArgs e)
        {
            lists.Clear();
            Lists l1 = new Lists();
            foreach(List_item element in l1)
            {
                lists.Add(element);

            }
        }
    }
}
