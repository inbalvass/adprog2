using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;


namespace server
{
    interface IMultiGame
    {
        /// <summary>
        /// set the TcpClient that joined the game
        /// </summary>
        /// <param name="client">the client</param>
        void setJoinClient(TcpClient client);

        /// <summary>
        /// get the maze
        /// </summary>
        /// <returns></returns>
        Maze getMaze();

        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        string getName();

        /// <summary>
        /// set the maze
        /// </summary>
        /// <param name="maze">the maze</param>
        void setMaze(Maze maze);

        /// <summary>
        /// get the client that start the connection
        /// </summary>
        /// <returns></returns>
        TcpClient getStartClient();

        /// <summary>
        /// get the client that joined the game
        /// </summary>
        /// <returns></returns>
        TcpClient getJoinClient();

        /// <summary>
        /// send the meesage to the client it get
        /// </summary>
        /// <param name="client"> the client to send it the message</param>
        /// <param name="message"> the message to send</param>
        void sendMessage(TcpClient client, string message);
    }
}
