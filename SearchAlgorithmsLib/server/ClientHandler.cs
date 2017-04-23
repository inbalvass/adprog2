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
    /// deal with the client. it get the client order and on new task execute it.
    /// </summary>
    class ClientHandler : IClientHandler
    {
        /// <summary>
        /// the controller
        /// </summary>
        private IController control;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="controller"> the controller</param>
        public ClientHandler(IController controller)
        {
            control = controller;
        }

        /// <summary>
        /// create new task and execute the command
        /// </summary>
        /// <param name="client">the client that it deal with</param>
        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {

                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    string command;
                    while ((command = reader.ReadString()) != null)
                    {
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
