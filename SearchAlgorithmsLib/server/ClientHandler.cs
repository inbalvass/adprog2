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
            //אולי זה צריך היות למעשה במיין ולא פה
            control.setClientHandler(this);
        }
        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.AutoFlush = true;
                    while (true)
                    {
                        string command = reader.ReadLine();
                        if (command != null)
                        {
                            string result = control.ExecuteCommand(command, client);
                            writer.Write(result);
                        }
                        else
                        {
                            break; // Client closed connection
                        }
                    }
                }
                //לבדוק את זה!! אולי צריך להיות פה איזו לולאת וויאל
                client.Close();
            }).Start();
        }
    }
}
