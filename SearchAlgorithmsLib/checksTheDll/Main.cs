using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checksTheDll
{
    class Main
    {
        public static void main(string[] args)
        {
            int rows = 10;
            int cols = 10;
            Program prog = new Program(rows,cols);
            prog.CompareSolver();
        }
    }
}
