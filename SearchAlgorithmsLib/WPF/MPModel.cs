using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class MPModel
    {
        private Client myClient;
        private string _mazeStr;

        public MPModel(Client client)
        {
            this.myClient = client;
        }
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

        public void play(string move)
        {
            string command = "play " + move;
            this.mazeStr = myClient.StartSingle(command);

        }
    }
}
