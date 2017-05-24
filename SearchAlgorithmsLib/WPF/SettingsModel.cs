using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class SettingsModel : ISettingsModel
    {
        /// <summary>
        /// get and set ip for binding
        /// </summary>
        public string IP
        {
            get { return Properties.Settings.Default.IP; }
            set { Properties.Settings.Default.IP = value; }
        }

        /// <summary>
        /// get and set Port for binding
        /// </summary>
        public int Port
        {
            get { return Properties.Settings.Default.Port; }
            set { Properties.Settings.Default.Port = value; }
        }

        /// <summary>
        /// get and set Rows for binding
        /// </summary>
        public int DefRows
        {
            get { return Properties.Settings.Default.DefRows; }
            set { Properties.Settings.Default.DefRows = value; }
        }

        /// <summary>
        /// get and set Cols for binding
        /// </summary>
        public int DefCols
        {
            get { return Properties.Settings.Default.DefCols; }
            set { Properties.Settings.Default.DefCols = value; }
        }

        /// <summary>
        /// get and set the algorithm for binding
        /// </summary>
        public int DefAlgo
        {
            get { return Properties.Settings.Default.DefAlgo; }
            set { Properties.Settings.Default.DefAlgo = value; }
        }

        /// <summary>
        /// save settings
        /// </summary>
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
