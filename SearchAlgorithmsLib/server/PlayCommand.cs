using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace server
{
    /// <summary>
    /// this class defines rhe command of "play", and implements the ICommand interface.
    /// </summary>
    class PlayCommand : ICommand
    {
        /// <summary>
        /// holdes the model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">the model</param>
        public PlayCommand(IModel model)
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
            //this do nothing because the task don't read it
            Console.WriteLine("after send");
            return message;
        }

        /// <summary>
        /// this function returns a Json format of the command.
        /// </summary>
        /// <returns></returns>
        private string ToJson(string move, string name)
        {
            JObject moveObj = new JObject();
            moveObj["Name"] = name;
            moveObj["Direction"] = move;
            return moveObj.ToString();
        }
    }
}
