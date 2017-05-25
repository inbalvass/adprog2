using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// the view model class for the single player window.
    /// </summary>
    class SPWindowViewModel : ViewModel
    {
        private SPWindowModel model;

        /// <summary>
        /// constructor
        /// </summary>
        public SPWindowViewModel()
        {
            this.model = new SPWindowModel();
        }

        /// <summary>
        /// the VM_mazeStr property
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
        /// asking the model to generate a new maze
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <param name="row">the number of rows</param>
        /// <param name="col">the number of columns</param>
        public void generate(string name, int row, int col)
        {
            model.generate(name,row,col);
        }

        /// <summary>
        /// asking the model to solve the maze
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <returns></returns>
        public string solve(string name)
        {
            return model.solve(name);
        }
    }
}
