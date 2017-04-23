﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using System.Net.Sockets;

namespace server
{
    /// <summary>
    /// part of the controller- it get the solve command and solve the maze.
    /// </summary>
    class SolveMazeCommand : ICommand
    {
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model"> the model</param>
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// executiong the solve command and return json that represent the soolution
        /// </summary>
        /// <param name="args"></param>
        /// <param name="client"> the TcpClient that asked for the solution</param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
            string sol = model.SolveMazeCommand(name,algorithm);
            return sol;
        }
    }
}
