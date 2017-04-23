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
        /// <summary>
        /// get the kind of command and execute it. then return the answer
        /// </summary>
        /// <param name="commandLine"> the string gets from the client</param>
        /// <param name="client">the client that send the message</param>
        /// <returns></returns>
        string ExecuteCommand(string commandLine, TcpClient client);

        /// <summary>
        /// set the client handler
        /// </summary>
        /// <param name="clientHandler">the client handler</param>
        void setClientHandler(IClientHandler clientHandler);
    }
}
