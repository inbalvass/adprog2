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
using System.Threading;

namespace WPF
{
    /// <summary>
    /// Interaction logic for WaitForConnection.xaml
    /// </summary>
    public partial class WaitForConnection : Window
    {
        private Client client;
        private string name;
        public WaitForConnection(string names,Client myClient, MultiPlayer befor)
        {
            InitializeComponent();
            befor.Close();
            this.client = myClient;
            this.name = names;
            this.Show();
            GetEvent();
        }

        public void GetEvent()
        {
            bool resualtChanged = client.isResualtChanged();
            //try to get the result
            while (!resualtChanged)
            {
                Thread.Sleep(100);
                resualtChanged = client.isResualtChanged();
            }
            string json = client.getResault();

            Label l = new Label();
            l.Content = json;
            grid.Children.Add(l);
            MPwindow wind = new MPwindow(this.name, this.client, json);
            this.Close();
            wind.ShowDialog();
        }
    }
}
