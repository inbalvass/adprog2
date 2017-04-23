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
    class Program
    {
        static void Main(string[] args)
        {
            //the client run all the time
            while (true)
            {
                //את זה נוציא למיין ואז נפתח חיבור רק ברגע שהלקוח רוצה לשלוח הודעה ולא סתם
                Console.WriteLine("write your command");
                string command = Console.ReadLine();
                Client client = new Client(int.Parse(ConfigurationManager.AppSettings["port"]));
                client.Start(command);
            }
        }
    }
}