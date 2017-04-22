using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Controller : IController
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;
        private IClientHandler clientHandler;
        public Controller()
        {
            commands = new Dictionary<string, ICommand>();  
        }

        public void setModel(IModel mod)
        {
            model = mod;
            addCommands();
        }

        public void setClientHandler(IClientHandler clientHandler)
        {
            this.clientHandler = clientHandler;
        }

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

        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }
    }
}
