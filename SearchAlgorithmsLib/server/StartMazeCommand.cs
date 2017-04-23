using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace server
{
    /// <summary>
    /// this class defines rhe command of "start", and implements the ICommand interface.
    /// </summary>
    class StartMazeCommand : ICommand
    {
        /// <summary>
        /// holdes the model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public StartMazeCommand(IModel model)
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
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);

            multiGame game = new multiGame(name, client);
            string str = model.StartMazeCommand(name, rows, cols, game);
            //wait until another client is connected to the game
            while (!game.isConnected())
            {
                Thread.Sleep(1000);
            }
            return str;
        }
    }
}
