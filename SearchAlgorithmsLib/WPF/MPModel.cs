using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WPF
{
    /// <summary>
    /// the model class
    /// </summary>
    class MPModel
    {
        private Client myClient;
        private string _mazeStr;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="client"></param>
        public MPModel(Client client)
        {
            this.myClient = client;
        }

        /// <summary>
        /// get and set the mazeStr
        /// </summary>
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

        /// <summary>
        /// play command
        /// </summary>
        /// <param name="move"></param>
        public void Play(string move)
        {
            string command = "play " + move;
            myClient.SetPlayCommand(command);
        }

        /// <summary>
        /// close command
        /// </summary>
        /// <param name="name"></param>
        public void Close(string name)
        {
            string command = "close " + name;
            myClient.SetPlayCommand(command);            
        }
    }
}
