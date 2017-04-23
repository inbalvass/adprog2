using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace server
{
    /// <summary>
    /// this function handles the connection to the client.
    /// </summary>
    class ClientHandler : IClientHandler
    {
        /// <summary>
        /// holdes the controller
        /// </summary>
        private IController control;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="controller"></param>
        public ClientHandler(IController controller)
        {
            control = controller;
        }

        /// <summary>
        /// this function handles the connection and requests from the client.
        /// </summary>
        /// <param name="client">the client to handle.
        /// </param>
        public void HandleClient(TcpClient client)
        {
            Console.WriteLine("in HandleClient");
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    Console.WriteLine("in HandleClient new task");
                    string command;
                    while ((command = reader.ReadString()) != null)
                    {
                        Console.WriteLine("in HandleClient" + client);
                        Console.WriteLine("command " + command);
                        string result = control.ExecuteCommand(command, client);
                        Console.WriteLine(result);
                        
                        if (!command.StartsWith("play"))
                        {
                            writer.Write(result);
                        }

                        if (command.StartsWith("generate") || command.StartsWith("solve") ||
                        command.StartsWith("close") || command == "b")
                        {
                            //close the connection
                            break;
                        }
                    }
                }
                client.Close();
            }).Start();
        }
    }
}
