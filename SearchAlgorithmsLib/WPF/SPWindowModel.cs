using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF
{
    class SPWindowModel 
    {
        private Client myClient;
        private string _mazeStr;
        public string mazeStr
        {
            get
            {
                return _mazeStr;
            }
            set
            {
                this._mazeStr = value;

            }
        }

        public SPWindowModel()
        {
            
        }

        public void generate(string name,int row,int col)
        {
            myClient = new Client();
            string command = "generate " + name + " " + row + " " + col;
            this.mazeStr = myClient.StartSingle(command);
   
        }

        public string solve(string name)
        {
            myClient = new Client();
            string command = "solve " + name + " " + Properties.Settings.Default.DefAlgo;
            return myClient.StartSingle(command);
        }

        

    }
}
