using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    interface IController
    {
        string ExecuteCommand(string commandLine, TcpClient client);
    }
}
