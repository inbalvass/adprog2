using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class SPWindowModel
    {
        private Client myClient;
        public SPWindowModel()
        {
            myClient = new Client();
        }

        public string generate(string name,int row,int col)
        {
            string command = "generate " + name + " " + row + " " + col;
            return myClient.StartSingle(command);
        }

        public string solve(string name)
        {
            string command = "solve " + name + " " + Properties.Settings.Default.DefAlgo;
            return myClient.StartSingle(command);
        }
    }
}
