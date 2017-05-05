using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;
        public SettingsViewModel()
        {
            this.model = new SettingsModel();
        }
        public string ServerIP
        {
            get { return model.IP; }
            set
            {
                model.IP = value;
                NotifyPropertyChanged("IP");
            }
        }
        public int ServerPort
        {
            get { return model.Port; }
            set
            {
                model.Port = value;
                NotifyPropertyChanged("Port");
            }
        }
        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}
