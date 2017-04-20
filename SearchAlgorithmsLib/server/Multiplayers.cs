using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


//את זה צריך למחוק. 
namespace server
{
    abstract class Multiplayers : ICommand
    {
        protected IModel model { get; }
        private Dictionary<TcpClient, IMultiGame> games;

        public Multiplayers(IModel model)
        {
            this.model = model;
            games = new Dictionary<TcpClient, IMultiGame>();
        }

        public void addGame(IMultiGame game, TcpClient client)
        {
            games.Add(client, game);
        }

        public abstract string Execute(string[] args, TcpClient client);
    }
}
