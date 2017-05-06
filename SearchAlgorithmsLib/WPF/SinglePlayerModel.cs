using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    //כאן צריך להיות את העדכון של המשחק עצמו- כנראה לפה צריך להיכנס כל הקוד שנעשה בקליינט ללא הגואי
    class SinglePlayerModel : ISinglePlayerModel
    {
        public string Name
        {
            get { return Name; }
            set { /*Name = Name;*/ }
        }
        public int Colomns
        {
            get { return Properties.Settings.Default.Port; }
            set { Properties.Settings.Default.Port = value; }
        }

        public int Rows
        {
            get { return Rows; }
            set { Properties.Settings.Default.DefRows = value; }
        }
        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }
    }
}
