using System.Net.Sockets;

namespace server
{
    internal interface IClientHandler
    {
        void HandleClient(TcpClient client);
    }
}