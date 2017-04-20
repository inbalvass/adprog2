using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace server
{
    interface IController
    {
        string ExecuteCommand(string commandLine, TcpClient client);
        void setClientHandler(IClientHandler clientHandler);
    }
}
