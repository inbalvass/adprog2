using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace server
{
    /// <summary>
    /// this class defines rhe command of "list, and implements the ICommand interface.
    /// </summary>
    class ListCommand : ICommand
    {
        /// <summary>
        /// holdes the model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public ListCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// this function executes the command of this class.
        /// </summary>
        /// <param name="args">the arguments for the command.
        /// </param>
        /// <param name="client"></param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client)
        {
            
            string lst = model.ListCommand();
            return lst;
        }
    }
}
