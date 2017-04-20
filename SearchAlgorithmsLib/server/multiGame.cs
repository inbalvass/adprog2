using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;

namespace server
{
    class multiGame : IMultiGame
    {
        public string name { get; }
        public TcpClient client1 { get; }
        public TcpClient client2 { get; set; }
        private Maze maze;
        HandleGame hg;

        public multiGame(string name, TcpClient client)
        {
            this.name = name;
            client1 = client;
            client2 = null;

        }

        public Maze getMaze()
        {
            return this.maze;
        }

        public void setJoinClient(TcpClient client)
        {
            client2 = client;
        }

        public void setMaze(Maze maze)
        {
            this.maze = maze;
        }

        public bool isConnected()
        {
            if (null == client2)
            {
                return false;
            }
            return true;
        }

        public void CreateConnection(IController controller)
        {
            hg = new HandleGame(controller);
            hg.HandleClients(this.client1);
            hg.HandleClients(this.client2);
        }

        public void sendMessage(TcpClient client,string move)
        {
            hg.sendMove(client, move);
        }
    }


}
