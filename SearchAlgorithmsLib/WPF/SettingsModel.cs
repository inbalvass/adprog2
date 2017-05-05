using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class SettingsModel : ISettingsModel
    {
        public string IP
        {
            get { return Properties.Settings.Default.IP; }
            set { Properties.Settings.Default.IP = value; }
        }
        public int Port
        {
            get { return Properties.Settings.Default.Port; }
            set { Properties.Settings.Default.Port = value; }
        }

        public int DefRows
        {
            get { return Properties.Settings.Default.DefRows; }
            set { Properties.Settings.Default.DefRows = value; }
        }
        public int DefCols
        {
            get { return Properties.Settings.Default.DefCols; }
            set { Properties.Settings.Default.DefCols = value; }
        }
        public int DefAlgo
        {
            get { return Properties.Settings.Default.DefAlgo; }
            set { Properties.Settings.Default.DefAlgo = value; }
        }
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
