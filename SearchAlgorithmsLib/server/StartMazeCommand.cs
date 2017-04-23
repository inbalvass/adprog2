using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace server
{
    class StartMazeCommand : ICommand
    {
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);

            multiGame game = new multiGame(name, client);
            string str = model.StartMazeCommand(name, rows, cols, game);
            //waut untiol another client is connected to the game
            while (!game.isConnected())
            {
                Thread.Sleep(1000);
            }
            return str;
        }
    }
}
