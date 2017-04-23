using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace server
{
    class ListCommand : ICommand
    {
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public ListCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            
            string lst = model.ListCommand();
            return lst;
        }
    }
}
