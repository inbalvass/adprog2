using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class MPViewModel : ViewModel
    {
        private MPModel model;

        public MPViewModel(Client client)
        {
            this.model = new MPModel(client);
        }

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

        public void play(string move)
        {
            model.play(move);
        }

        public void close(string name)
        {
            model.close(name);
        }
    }
}
