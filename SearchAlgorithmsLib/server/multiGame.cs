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
    /// <summary>
    /// functions for the multy-game
    /// </summary>
    class multiGame : IMultiGame
    {
        /// <summary>
        /// the maze name
        /// </summary>
        private string name;
        /// <summary>
        /// the client that start the connection
        /// </summary>
        private TcpClient client1;

        /// <summary>
        /// the client that join the connection
        /// </summary>
        private TcpClient client2;

        /// <summary>
        /// the maze
        /// </summary>
        private Maze maze;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"> the maze name</param>
        /// <param name="client">the client that start the connection</param>
        public multiGame(string name, TcpClient client)
        {
            this.name = name;
            client1 = client;
            client2 = null;

        }

        /// <summary>
        /// get the client that start the connection
        /// </summary>
        /// <returns></returns>
        public TcpClient getStartClient() { return client1; }

        /// <summary>
        /// get the client that joined the game
        /// </summary>
        /// <returns></returns>
        public TcpClient getJoinClient() { return client2; }

        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public string getName() { return name; }

        /// <summary>
        /// get the maze
        /// </summary>
        /// <returns></returns>
        public Maze getMaze(){return this.maze;}

        /// <summary>
        /// set the TcpClient that joined the game
        /// </summary>
        /// <param name="client">the client</param>
        public void setJoinClient(TcpClient client) { client2 = client; }

        /// <summary>
        /// set the maze
        /// </summary>
        /// <param name="maze">the maze</param>
        public void setMaze(Maze maze) { this.maze = maze; }

        /// <summary>
        /// check if there is a connection by check if there is 2 clients
        /// </summary>
        /// <returns></returns>
        public bool isConnected()
        {
            if (null == client2)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// send the meesage to the client it get
        /// </summary>
        /// <param name="client"> the client to send it the message</param>
        /// <param name="message"> the message to send</param>
        public void sendMessage(TcpClient client, string result)
        {
            new Task(() =>
            {
                NetworkStream stream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(stream);
                {
                    Console.WriteLine("send message" + result);
                    writer.Write(result);
                }
            }).Start();
        }
    }


}
