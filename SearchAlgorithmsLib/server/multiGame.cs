using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;
using System.IO;

namespace server
{
    class multiGame : IMultiGame
    {
        private string name;
        private TcpClient client1;
        private TcpClient client2;
        private Maze maze;

        public multiGame(string name, TcpClient client)
        {
            this.name = name;
            client1 = client;
            client2 = null;

        }

        public TcpClient getStartClient() { return client1; }
        public TcpClient getJoinClient() { return client2; }
        public string getName() { return name; }
        public Maze getMaze(){return this.maze;}
        public void setJoinClient(TcpClient client) { client2 = client; }
        public void setMaze(Maze maze) { this.maze = maze; }

        public bool isConnected()
        {
            if (null == client2)
            {
                return false;
            }
            return true;
        }

        //טאסק בשביל שישלח את ההודעה שצריך לקליינט
        public void sendMessage(TcpClient client, string result)
        {
            Console.WriteLine("ss");
            
            new Task(() =>
            {
                Console.WriteLine("send message");
                NetworkStream stream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(stream);
                {
                    Console.WriteLine("in send message" + result);
                    writer.Write(result);
                }
            }).Start();
        }
    }


}
