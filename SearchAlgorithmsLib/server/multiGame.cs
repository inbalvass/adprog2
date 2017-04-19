using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace server
{
    class multiGame : IMultiGame
    {
        private string name;
        private TcpClient client1;
        private TcpClient client2;

        public multiGame(string nm , TcpClient client)
        {
            name = nm;
            client1 = client;
            client2 = null;
        }

        public void setClient2(TcpClient client)
        {
            client2 = client;
        }

        public bool isConnected()
        {
            if(null == client2)
            {
                return false;
            }
            return true;
        }
    }
}
