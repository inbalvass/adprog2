using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// interface for the single player model
    /// </summary>
    interface ISinglePlayerModel
    {
        /// <summary>
        /// get and set the name for binding
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// get and set the colomns for binding
        /// </summary>
        int Colomns { get; set; }
        /// <summary>
        /// get and set the rows for binding
        /// </summary>
        int Rows { get; set; }
        /// <summary>
        /// save settings
        /// </summary>
        void SaveChanges();
    }
}
