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
        private string name;
        private int rows, cols;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int Colomns
        {
            get { return cols; }
            set { this.cols = value; }
        }

        public int Rows
        {
            get { return rows; }
            set { this.rows = value; }
        }
        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }
    }
}
