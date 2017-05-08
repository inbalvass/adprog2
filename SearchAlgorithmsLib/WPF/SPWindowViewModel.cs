using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class SPWindowViewModel
    {
        private SPWindowModel model;
        public SPWindowViewModel()
        {
            this.model = new SPWindowModel();
        }


        public string generate(string name, int row, int col)
        {
            return model.generate(name,row,col);
        }
    }
}
