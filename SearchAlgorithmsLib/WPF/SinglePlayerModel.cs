using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// the model class for single player
    /// </summary>
    class SinglePlayerModel : ISinglePlayerModel
    {
        private string name;
        private int rows, cols;

        /// <summary>
        /// constructor.
        /// </summary>
        public SinglePlayerModel()
        {
            rows = Properties.Settings.Default.DefRows;
            cols = Properties.Settings.Default.DefCols;
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Columns property
        /// </summary>
        public int Colomns
        {
            get { return cols; }
            set { this.cols = value; }
        }

        /// <summary>
        /// Rows property
        /// </summary>
        public int Rows
        {
            get { return rows; }
            set { this.rows = value; }
        }

        /// <summary>
        /// save the changes in the maze definition
        /// </summary>
        public void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }
    }
}
