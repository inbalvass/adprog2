﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(8000, new Controller.ClientHandler());
            server.Start();
            Console.ReadKey();
        }
    }
}
