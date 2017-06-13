using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    public class SinglePlayerModel
    {
        public string Name { get; set; }

        public SinglePlayerModel(string name)
        {
            Name = name;
        }
    }
}