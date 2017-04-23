using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    /// <summary>
    /// this class represents a server.
    /// </summary>
    class Server
    {
        /// <summary>
        /// TcpListener to listen to connections, a port to contact the clients and a
        /// clientHandler to handle clients requests. 
        /// </summary>
        private int port;
        private TcpListener listener;
        private IClientHandler ch;

        /// <summary>
        /// a cinstructor.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ch"></param>
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }
        /// <summary>
        /// this function runs the server. wait for clients and for each client opens
        /// a new task to handle the requests.
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

        /// <summary>
        /// stop the listener from listening to connections.
        /// </summary>
        public void Stop()
        {
            listener.Stop();
        }

    }
}
