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
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string command = reader.ReadLine();
                    //לבדוק איזו פקודה קיבלנו ולהביא אותה מהמילון
                    //לא צריך לבדוק איזו פקודה קיבלנו כי האקסקיוט כבר עושה את זה
                    string result = control.ExecuteCommand(command, client);
                    writer.Write(result);
                }
                client.Close();
            }).Start();
        }
    }
}
