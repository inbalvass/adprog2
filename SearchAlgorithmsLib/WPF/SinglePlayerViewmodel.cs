using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// the single player view model class.
    /// </summary>
    class SinglePlayerViewModel : ViewModel
    {
        //the model field
        private ISinglePlayerModel model;

        /// <summary>
        /// constructor.
        /// </summary>
        public SinglePlayerViewModel()
        {
            this.model = new SinglePlayerModel();
        }

        /// <summary>
        /// the Name property.
        /// </summary>
        public string Name
        {
            get { return model.Name; }
            set
            {
                model.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// the Columns property.
        /// </summary>
        public int Colomns
        {
            get { return model.Colomns; }
            set
            {
                model.Colomns = value;
                NotifyPropertyChanged("Colomns");
            }
        }

        /// <summary>
        /// the Rows property.
        /// </summary>
        public int Rows
        {
            get { return model.Rows; }
            set
            {
                model.Rows = value;
                NotifyPropertyChanged("Rows");
            }
        }

        /// <summary>
        /// save the changes in the maze definitions.
        /// </summary>
        public void SaveSettings()
        {
            model.SaveChanges();
        }
    }
}
