using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Server
    {
        private int port;
        private TcpListener listener;
        private IClientHandler ch;
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }
        /// <summary>
        /// run the server. wait for client and for each client it open new task to deal with the orders
        /// </summary>
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start();
            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("client in server class  " + client);
                        ch.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
            });
            task.Start();
        }
        public void Stop()
        {
            listener.Stop();
        }

    }
}
