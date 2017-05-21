using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WPF
{
    class MultyPlayerModel
    {
        private string name;
        private int rows, cols;
        private string _list;

        public MultyPlayerModel()
        {
            rows = Properties.Settings.Default.DefRows;
            cols = Properties.Settings.Default.DefCols;
        }

        
        public string list
        {
            get
            {
                return _list;
            }
            set
            {
                this._list = value;

            }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int Colomns
        {
            get { return cols; }
            set { this.cols = value; }
        }

        public int Rows
        {
            get { return rows; }
            set { this.rows = value; }
        }
        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }

        public string ListStart()
        {
            Client myClient = new Client();
            string command = "list";
            string result = myClient.StartSingle(command);
            return result;
        }


        public void start(Client client)
        {
            string command = "start " + name + " " + rows + " " + cols;
            client.StartMulty(command);
        }

        public string join(Client client)
        {
            string command = "join " + name;
            client.StartMulty(command);
            bool resualtChanged = client.isResualtChanged();
            //try to get the result
            while (!resualtChanged)
            {
                Thread.Sleep(100);
                resualtChanged = client.isResualtChanged();
            }
            string json = client.getResault();
            return json;

        }
    }
}
