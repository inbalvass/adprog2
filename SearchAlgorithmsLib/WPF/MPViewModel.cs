using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// vm class for the multy player window (mpwidow)
    /// </summary>
    class MPViewModel : ViewModel
    {
        private MPModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="client"></param>
        public MPViewModel(Client client)
        {
            this.model = new MPModel(client);
        }

        /// <summary>
        /// get and set the mazeStr
        /// </summary>
        public string VM_mazeStr
        {
            get
            {
                return this.model.mazeStr;
            }
            set
            {
                model.mazeStr = value;
                NotifyPropertyChanged("mazeStr");
            }
        }

        /// <summary>
        /// play command
        /// </summary>
        /// <param name="move"></param>
        public void Play(string move)
        {
            model.Play(move);
        }

        /// <summary>
        /// close command
        /// </summary>
        /// <param name="name"></param>
        public void Close(string name)
        {
            model.Close(name);
        }
    }
}
