using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace client
{
    /// <summary>
    /// the main class that runs the client.
    /// </summary>
    /// <param name="args"></param>
    class Program
    {
        /// <summary>
        /// the main function that runs the client.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //the client run all the time
            while (true)
            {
                Console.WriteLine("write your command");
                string command = Console.ReadLine();
                int port = Int32.Parse(ConfigurationManager.AppSettings["port"]);
                Client client = new Client(port);
                client.Start(command);
            }
        }
    }
}