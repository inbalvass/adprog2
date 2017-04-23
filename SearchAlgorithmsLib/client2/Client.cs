using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        public void Start(string commands)
        {
            string command = commands;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client.Connect(ep);
            //Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {             
                while (true)
                {
                    // Send data to server
                    writer.Write(command);
                    // Get result from server.if this is play command so dont wait for answer
                    if (!command.StartsWith("play") && !command.StartsWith("close"))
                    {
                        string result = reader.ReadString();
                        Console.WriteLine(result);
                    }
                    if (command.StartsWith("start") || command.StartsWith("join"))
                    {
                        new Task(() =>
                        {
                            while (true)
                            {
                                Console.WriteLine("new task form client");
                                string result = reader.ReadString();
                                Console.WriteLine("new task " + result);

                                if (result.Contains("close"))
                                {
                                    //צריך לתת מה לעשות כי זה ממש נסגר רק אחרי פקודת גנרט או סולב
                                    Console.WriteLine("connection closed. type b to continue");
                                    break;
                                }
                            }
                        }).Start();
                    }
                    if (command.StartsWith("generate") || command.StartsWith("solve") ||
                        command.StartsWith("close") || command == "b")

                    {
                        
                        Thread.Sleep(100); //so the task closed first
                        Console.WriteLine("client close");
                        //close the connection
                        Stop();
                        break;
                    }
                    Console.WriteLine("write your command");
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
