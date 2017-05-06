using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    //המשמעות של הסטינגס זה להעביר מידע בין הרצות. כנראה המידע שפה לא אמור להיות בסטינגס כי זה לא בין הרצות.
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
            get { return Rows; }
            set { this.rows = value; }
        }
        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }
    }
}
