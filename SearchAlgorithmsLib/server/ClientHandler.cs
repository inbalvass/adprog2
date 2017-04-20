using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace server
{
    class ClientHandler : IClientHandler
    {
        private IController control;
        public ClientHandler(IController controller)
        {
            control = controller;

        }

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
                 //   writer.AutoFlush = true;
                    string command;
                    while ((command = reader.ReadString()) != null)  //במקום while true  נכון שזה מקסים?? 
                    {
                        Console.WriteLine("command" + command);
                        string result = control.ExecuteCommand(command, client);
                        writer.Write(result);
                    }
                }
                //לבדוק את זה!! אולי צריך להיות פה איזו לולאת וויאל
                client.Close();
            }).Start();
        }
    }
}
