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

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="names"></param>
        /// <param name="myClient"></param>
        /// <param name="befor"></param>
        public WaitForConnection(string names,Client myClient, MultiPlayer befor)
        {
            InitializeComponent();
            befor.Close();
            this.client = myClient;
            this.name = names;
            this.Show();
            GetEvent();
        }

        /// <summary>
        /// waiting for connection until a new player joins
        /// </summary>
        public void GetEvent()
        {
            bool resualtChanged = client.IsResualtChanged();
            //try to get the result
            while (!resualtChanged)
            {
                Thread.Sleep(10);
                resualtChanged = client.IsResualtChanged();
            }
            string json = client.GetResault();

            MPwindow wind = new MPwindow(this.name, this.client, json);
            this.Close();
            wind.ShowDialog();
        }
    }
}
