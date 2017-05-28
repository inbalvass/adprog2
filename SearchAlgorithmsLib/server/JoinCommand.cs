using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;

namespace server
{
    /// <summary>
    /// this class defines rhe command of "join", and implements the ICommand interface.
    /// </summary>
    class JoinCommand : ICommand
    {
        /// <summary>
        /// holdes the model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public JoinCommand(IModel model)
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
            string name = args[0];
            IMultiGame game = model.JoinCommand(name);
            game.SetJoinClient(client);
            return game.GetMaze().ToJSON();
        }
    }
}
