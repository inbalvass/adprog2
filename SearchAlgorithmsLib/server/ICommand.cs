using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    interface ICommand
    {
       // string Execute(string[] args, TcpClient client = null);
        string Execute(string[] args, TcpClient client);
    }
}
