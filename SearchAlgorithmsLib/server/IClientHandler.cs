using System.Net.Sockets;

namespace server
{
    internal interface IClientHandler
    {
        /// <summary>
        /// create new task and execute the command
        /// </summary>
        /// <param name="client">the client that it deal with</param>
        void HandleClient(TcpClient client);
    }
}