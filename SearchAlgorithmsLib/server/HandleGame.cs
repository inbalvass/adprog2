using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace server
{
    class HandleGame
    {
        private IController control;

        public HandleGame(IController controller)
        {
            control = controller;
        }
        public void HandleClients(TcpClient client)
        {
            //טאסק בשביל שכל הזמן יקרא מהלקוח ואז ישלח לשרת
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    while (true)
                    {
                        string command = reader.ReadLine();
                        control.ExecuteCommand(command, client);
                    }
                }
            }).Start();
        }

        //טאסק בשביל שישלח את ההודעה שצריך לקליינט
        public void sendMove(TcpClient client, string result)
        {
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(result);
                }
            }).Start();
        }
    }
}
