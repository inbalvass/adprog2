using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using System.Net.Sockets;

namespace server
{
    /// <summary>
    /// this class defines rhe command of "generate", and implements the ICommand interface.
    /// </summary>
    class GenerateMazeCommand : ICommand
    {
        /// <summary>
        /// holdes the model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="model">the model</param>
        public GenerateMazeCommand(IModel model)
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
            Maze maze = model.GenerateMaze(name, rows, cols);
            return maze.ToJSON();
        }
    }
}
