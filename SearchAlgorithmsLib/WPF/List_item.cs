using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    /// <summary>
    /// class for the binding of the list of games
    /// </summary>
    class List_item
    {
        public string Name { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="str"></param>
        public List_item(string str)
        {
            this.Name = str;
        }
    }
}
