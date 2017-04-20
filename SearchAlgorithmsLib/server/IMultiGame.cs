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
        void setJoinClient(TcpClient client);
        Maze getMaze();
        void setMaze(Maze maze);
    }
}
