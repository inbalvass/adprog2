using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WPF
{
    /// <summary>
    /// class for the multy player settings
    /// </summary>
    class MultyPlayerModel
    {
        private string name;
        private int rows, cols;
        /// <summary>
        /// constructor
        /// </summary>
        public MultyPlayerModel()
        {
            rows = Properties.Settings.Default.DefRows;
            cols = Properties.Settings.Default.DefCols;
        }

        /// <summary>
        /// get and set Name for binding
        /// </summary>
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        /// <summary>
        /// get and set Colomns for binding
        /// </summary>
        public int Colomns
        {
            get { return cols; }
            set { this.cols = value; }
        }

        /// <summary>
        /// get and set rows for binding
        /// </summary>
        public int Rows
        {
            get { return rows; }
            set { this.rows = value; }
        }

        /// <summary>
        /// save changes
        /// </summary>
        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// the list command
        /// </summary>
        /// <returns></returns>
        public string ListStart()
        {
            Client myClient = new Client();
            string command = "list";
            string result = myClient.StartSingle(command);
            return result;
        }

        /// <summary>
        /// the start command
        /// </summary>
        /// <param name="client"></param>
        public void Start(Client client)
        {
            string command = "start " + name + " " + rows + " " + cols;
            client.StartMulty(command);
        }

        /// <summary>
        /// the join command
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public string Join(Client client)
        {
            string command = "join " + name;
            client.StartMulty(command);
            bool resualtChanged = client.IsResualtChanged();
            //try to get the result
            while (!resualtChanged)
            {
                Thread.Sleep(100);
                resualtChanged = client.IsResualtChanged();
            }
            string json = client.GetResault();
            return json;

        }
    }
}
