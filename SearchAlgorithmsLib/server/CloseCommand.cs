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
    /// this class defines rhe command of "close", and implements the ICommand interface.
    /// </summary>
    class CloseCommand : ICommand
    {
        /// <summary>
        /// holdes the model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="model">the model</param>
        public CloseCommand(IModel model)
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
            IMultiGame myGame = model.CloseCommand(name);
            TcpClient otherClient = null;

            if (myGame.GetStartClient() == client)
            {
                otherClient = myGame.GetJoinClient();
            }
            else
            {
                otherClient = myGame.GetStartClient();
            }

            string message = ToJson();
            myGame.SendMessage(otherClient, message);
            return message;
        }

        /// <summary>
        /// this function returns a Json format of the command.
        /// </summary>
        /// <returns></returns>
        private string ToJson()
        {
            JObject moveObj = new JObject();
            moveObj["close"] = "connection closed";
            return moveObj.ToString();
        }
    }
}
