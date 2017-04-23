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
    /// <summary>
    /// this class represents a client.
    /// </summary>
    class Client
    {
        /// <summary>
        /// TcpClient of the client and his port to contact the server.
        /// </summary>
        private TcpClient client;
        private int port;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="port"> the port to contact the server.
        /// </param>
        public Client(int port)
        {
            client = new TcpClient();
            this.port = port;
        }

        /// <summary>
        /// this function starts the client and establish the connection to the server.
        /// </summary>
        /// <param name="commands">the command to the server.
        /// </param>
        public void Start(string commands)
        {
            string command = commands;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client.Connect(ep);
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {             
                while (true)
                {
                    // Send data to server
                    writer.Write(command);
                    // Get result from server. if this is a play or close command so don't wait for answer
                    if (!command.StartsWith("play") && !command.StartsWith("close"))
                    {
                        string result = reader.ReadString();
                        if (command != "b")
                        {
                            Console.WriteLine(result);
                        }
                    }
                    if (command.StartsWith("start") || command.StartsWith("join"))
                    {
                        new Task(() =>
                        {
                            while (true)
                            {
                                string result = reader.ReadString();
                                Console.WriteLine(result);

                                if (result.Contains("close"))
                                {
                                    // after the other client closed the connection this client still
                                    //has to react with some flag of closing.
                                    Console.WriteLine("connection closed. type b to continue");
                                    break;
                                }
                            }
                        }).Start();
                    }
                    if (command.StartsWith("generate") || command.StartsWith("solve") ||
                        command.StartsWith("close") || command == "b")

                    {
                        //so the task closed first
                        Thread.Sleep(100);
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

        /// <summary>
        /// close the connection to the server.
        /// </summary>
        public void Stop()
        {
            client.Close();
        }
    }
}
