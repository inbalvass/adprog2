using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;

namespace server
{
    class JoinCommand : ICommand
    {
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public JoinCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            IMultiGame game = model.JoinCommand(name);
            game.setJoinClient(client);
            return game.getMaze().ToJSON();
        }
    }
}
