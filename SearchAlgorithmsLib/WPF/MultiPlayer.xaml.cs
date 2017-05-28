using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private MultyPlayerVM vm;
        private ObservableCollection<List_item> lists = new ObservableCollection<List_item>();

        /// <summary>
        /// constructor
        /// </summary>
        public MultiPlayer()
        {
            InitializeComponent();
            vm = new MultyPlayerVM();
            this.DataContext = vm;

            comboBox.ItemsSource = lists;
            comboBox.DisplayMemberPath = "Name";
        } 

        /// <summary>
        /// when press to create new multy game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_multi_game(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            Client client = new Client();
            vm.Start(client);
            WaitForConnection wfc = new WaitForConnection(vm.Name, client,this);
        }

        /// <summary>
        /// when pressed to join to a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Join_game(object sender, RoutedEventArgs e)
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
                string json = vm.Join(client);
                MPwindow wind = new MPwindow(vm.Name, client, json);
                this.Close();
                wind.ShowDialog();
            }
        }

        /// <summary>
        /// when pressed to open the list of games
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
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
