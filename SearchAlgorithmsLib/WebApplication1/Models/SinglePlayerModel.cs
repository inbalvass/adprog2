using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    public class SinglePlayerModel
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public SinglePlayerModel(string name,int rows,int colomns)
        {
            Name = name;
            Rows = rows;
            Cols = Cols;
        }
    }
}