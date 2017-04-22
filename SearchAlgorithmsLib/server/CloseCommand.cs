using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace server
{
    class CloseCommand : ICommand
    {
        private IModel model;

        public CloseCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            IMultiGame myGame = model.CloseCommand(name);
            TcpClient otherClient = null;

            if (myGame.getStartClient() == client)
            {
                otherClient = myGame.getJoinClient();
            }
            else
            {
                otherClient = myGame.getStartClient();
            }

            string message = ToJson();
            myGame.sendMessage(otherClient, message);
            return message;
        }

        private string ToJson()
        {
            JObject moveObj = new JObject();
            moveObj["close"] = "connection closed";
            return moveObj.ToString();
        }
    }
}
