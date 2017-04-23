using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    /// <summary>
    /// the controller- get the message from the client and execute it
    /// </summary>
    class Controller : IController
    {
        /// <summary>
        /// dictionary of the commands
        /// </summary>
        private Dictionary<string, ICommand> commands;
        /// <summary>
        /// the model
        /// </summary>
        private IModel model;
        /// <summary>
        /// the client handler
        /// </summary>
        private IClientHandler clientHandler;

        /// <summary>
        /// constructor
        /// </summary>
        public Controller()
        {
            commands = new Dictionary<string, ICommand>();  
        }

        /// <summary>
        /// set the model
        /// </summary>
        /// <param name="mod">the model</param>
        public void setModel(IModel mod)
        {
            model = mod;
            addCommands();
        }

        /// <summary>
        /// set the client handler
        /// </summary>
        /// <param name="clientHandler">the client handler</param>
        public void setClientHandler(IClientHandler clientHandler)
        {
            this.clientHandler = clientHandler;
        }

        /// <summary>
        /// add the kinds of commands and the class that execute them to the dictionary
        /// </summary>
        private void addCommands()
        {
            commands.Add("generate", new GenerateMazeCommand(model));
            commands.Add("solve", new SolveMazeCommand(model));
            commands.Add("start", new StartMazeCommand(model));
            commands.Add("list", new ListCommand(model));
            commands.Add("join", new JoinCommand(model));
            commands.Add("play", new PlayCommand(model));
            commands.Add("close", new CloseCommand(model));
        }

        /// <summary>
        /// get the kind of command and execute it. then return the answer
        /// </summary>
        /// <param name="commandLine"> the string gets from the client</param>
        /// <param name="client">the client that send the message</param>
        /// <returns></returns>
        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            try
            {
                return command.Execute(args, client);
            }
            catch(Exception e)
            {
                return "Exception "+e.Message;
            }
}
    }
}
