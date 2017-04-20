using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace server
{
    class PlayCommand : ICommand
    {
        private IModel model;

        public PlayCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            string move = args[0];
            IMultiGame myGame = null;
            TcpClient otherClient = null;

            //try to find the player's game
            foreach (IMultiGame game in model.getMultyGames().Values)
            {
                if (game.getStartClient() == client)
                {
                    myGame = game;
                    otherClient = game.getJoinClient();
                }
                else if (game.getJoinClient() == client)
                {
                    myGame = game;
                    otherClient = game.getStartClient();
                }
                else
                {
                    //game not found
                    return null;
                }
            }

            string message = ToJson(move, myGame.getName());
            myGame.sendMessage(otherClient, message);
            //this do nothing because it the task not read it
            return message;
        }

        private string ToJson(string move, string name)
        {
            JObject moveObj = new JObject();
            moveObj["Name"] = name;
            moveObj["Direction"] = move;
            return moveObj.ToString();
        }
    }
}
