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
            multiGame myGame = null;
            TcpClient otherClient = null;

            //try to find the player's game
            foreach (multiGame game in model.getMultyGames().Values)
            {
                if (game.client1 == client)
                {
                    myGame = game;
                    otherClient = game.client2;
                }
                else if (game.client2 == client)
                {
                    myGame = game;
                    otherClient = game.client1;
                }
                else
                {
                    //game not found
                    return null;
                }
            }

            string message = ToJson(move, myGame.name);
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
