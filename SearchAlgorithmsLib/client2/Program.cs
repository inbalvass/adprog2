using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            //the client run all the time
            while (true)
            {
                Console.WriteLine("write your command");
                string command = Console.ReadLine();
                Client client = new Client(8000);
                client.Start(command);
            }
        }
    }
}