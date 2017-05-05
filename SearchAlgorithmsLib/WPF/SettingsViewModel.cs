using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;
        public SettingsViewModel()
        {
            this.model = new SettingsModel();
        }
        public string IP
        {
            get { return model.IP; }
            set
            {
                model.IP = value;
                NotifyPropertyChanged("IP");
            }
        }
        public int Port
        {
            get { return model.Port; }
            set
            {
                model.Port = value;
                NotifyPropertyChanged("Port");
            }
        }

        public int DefCols
        {
            get { return model.DefCols; }
            set
            {
                model.DefCols = value;
                NotifyPropertyChanged("DefCols");
            }
        }

        public int DefRows
        {
            get { return model.DefRows; }
            set
            {
                model.DefRows = value;
                NotifyPropertyChanged("DefRows");
            }
        }

        public int DefAlgo
        {
            get { return model.DefAlgo; }
            set
            {
                model.DefAlgo = value;
                NotifyPropertyChanged("DefAlgo");
            }
        }

        public void SaveSettings()
        {
            model.SaveSettings();
        }



        //public string IP
        //{
        //    get { return (int)GetValue(IPProperty); }
        //    set { SetValue(IPProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for IP.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IPProperty =
        //    DependencyProperty.Register("IP", typeof(int), typeof(SettingsViewModel), new PropertyMetadata(0));


    }
}
