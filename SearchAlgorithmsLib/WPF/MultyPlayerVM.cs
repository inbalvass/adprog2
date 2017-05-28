using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// class for the multy player settings
    /// </summary>
    class MultyPlayerVM : ViewModel, INotifyPropertyChanged
    {
        private MultyPlayerModel model;

        /// <summary>
        /// constructor
        /// </summary>
        public MultyPlayerVM()
        {
            this.model = new MultyPlayerModel();
        }

        /// <summary>
        /// get and set Name for binding
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
        /// get and set Name for binding
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
        /// get and set Rows for binding
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
        /// save settings
        /// </summary>
            public void SaveSettings()
        {
            model.SaveChanges();
        }

        /// <summary>
        /// start command
        /// </summary>
        /// <param name="client"></param>
        public void Start(Client client)
        {
            model.Start(client);
        }

        /// <summary>
        /// join command
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public string Join(Client client)
        {
            return model.Join(client);
        }

        /// <summary>
        /// list command
        /// </summary>
        /// <returns></returns>
        public string ListStart()
        {
            return model.ListStart();
        }
    }
}
