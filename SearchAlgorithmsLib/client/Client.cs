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
    class Client
    {
        private TcpClient client;
        private int port;
        public Client(int port)
        {
            client = new TcpClient();
            this.port = port;
        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client.Connect(ep);
            //Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                string command = Console.ReadLine();
                while (true)
                {
                    // Send data to server
                    writer.Write(command);
                    // Get result from server
                    string result = reader.ReadString();
                    //צריך לבדוק שאחרי סטארט מתבצע ג'וין?
                    Console.WriteLine(result);
                    
                    if (command.StartsWith("generate") || command.StartsWith("solve") ||
                        command.StartsWith("close"))
                    {
                        //close the connection
                        Stop();
                        break;
                    }
                    command = Console.ReadLine();
                }
            }

        }
        public void Stop()
        {
            client.Close();
        }

    }
}
