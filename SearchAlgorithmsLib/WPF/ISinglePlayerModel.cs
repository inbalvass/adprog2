using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    interface ISinglePlayerModel
    {
        string Name { get; set; }
        int Colomns { get; set; }
        int Rows { get; set; }
        void SaveChanges();
    }
}
