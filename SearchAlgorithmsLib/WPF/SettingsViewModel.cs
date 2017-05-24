using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// view model for the settings
    /// </summary>
    class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;
        /// <summary>
        /// constructor
        /// </summary>
        public SettingsViewModel()
        {
            this.model = new SettingsModel();
        }

        /// <summary>
        /// get and set ip for binding
        /// </summary>
        public string IP
        {
            get { return model.IP; }
            set
            {
                model.IP = value;
                NotifyPropertyChanged("IP");
            }
        }

        /// <summary>
        /// get and set port for binding
        /// </summary>
        public int Port
        {
            get { return model.Port; }
            set
            {
                model.Port = value;
                NotifyPropertyChanged("Port");
            }
        }

        /// <summary>
        /// get and set Cols for binding
        /// </summary>
        public int DefCols
        {
            get { return model.DefCols; }
            set
            {
                model.DefCols = value;
                NotifyPropertyChanged("DefCols");
            }
        }

        /// <summary>
        /// get and set Rows for binding
        /// </summary>
        public int DefRows
        {
            get { return model.DefRows; }
            set
            {
                model.DefRows = value;
                NotifyPropertyChanged("DefRows");
            }
        }

        /// <summary>
        /// get and set the algorithm for binding
        /// </summary>
        public int DefAlgo
        {
            get { return model.DefAlgo; }
            set
            {
                model.DefAlgo = value;
                NotifyPropertyChanged("DefAlgo");
            }
        }

        /// <summary>
        /// save settings
        /// </summary>
        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}
