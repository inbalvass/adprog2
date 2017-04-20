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
            //כל עוד עוד לא התחברנו למשחק אחר תתן לטרד הנוכחי לישון וכך תשובה תחזור רק אחרי שהיה התחברות של שחקן אחר
            while (!game.isConnected())
            {
                Thread.Sleep(1000);
            }
           // game.sendMessage(client, str);
            return str;
        }
    }
}
