using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    /// <summary>
    /// this interface defines a command of the client.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// this function executes the command.
        /// </summary>
        /// <param name="args">the arguments for the command.
        /// </param>
        /// <param name="client"></param>
        /// <returns></returns>
        string Execute(string[] args, TcpClient client);
    }
}
