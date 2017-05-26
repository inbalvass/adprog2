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
    /// this class defines the controller of the MVC.
    /// </summary>
    class Controller : IController
    {
        /// <summary>
        /// a dictionary of different commands, the model of the MVC, and a clientHandler 
        /// object to handle clients.
        /// </summary>
        private Dictionary<string, ICommand> commands;
        private IModel model;
        private IClientHandler clientHandler;

        /// <summary>
        /// a constructor.
        /// </summary>
        public Controller()
        {
            commands = new Dictionary<string, ICommand>();  
        }

        /// <summary>
        /// this function sets the model property.
        /// </summary>
        /// <param name="mod">the new model.</param>
        public void SetModel(IModel mod)
        {
            model = mod;
            AddCommands();
        }

        /// <summary>
        /// this function sets the clientHandler property.
        /// </summary>
        /// <param name="mod">the new clientHandler.</param>
        public void SetClientHandler(IClientHandler clientHandler)
        {
            this.clientHandler = clientHandler;
        }

        /// <summary>
        /// this function add all the different commands to the dictionary.
        /// </summary>
        private void AddCommands()
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
        /// this function execute a curtain command from the client. 
        /// </summary>
        /// <param name="commandLine">the command and it's arguments.
        /// </param>
        /// <param name="client">the client</param>
        /// <returns></returns>
        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            Console.Write(commandLine);
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
