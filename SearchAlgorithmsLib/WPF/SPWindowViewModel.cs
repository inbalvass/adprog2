using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class SPWindowViewModel : ViewModel
    {
        private SPWindowModel model;
        public SPWindowViewModel()
        {
            this.model = new SPWindowModel();
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


        public void generate(string name, int row, int col)
        {
            model.generate(name,row,col);
        }

        public string solve(string name)
        {
            return model.solve(name);
        }
    }
}
