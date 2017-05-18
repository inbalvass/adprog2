using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class MultyPlayerModel
    {
        private string name;
        private int rows, cols;

        public MultyPlayerModel()
        {
            rows = Properties.Settings.Default.DefRows;
            cols = Properties.Settings.Default.DefCols;
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


        public void start(Client client)
        {
            string command = "start " + name + " " + rows + " " + cols;
            client.StartMulty(command);
        }
    }
}
