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
                    string command = reader.ReadLine();
                    string result = control.ExecuteCommand(command, client);
                    writer.Write(result);
                }
                //לבדוק את זה!! אולי צריך להיות פה איזו לולאת וויאל
                //בטוח שפה אמור להיות הסגירה? אם לאחר שליחת פקודה אחת זה יסגר אז לא יהיה אפשר לעשות משחק
                client.Close();
            }).Start();
        }
    }
}
