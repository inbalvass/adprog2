using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            Model model = new Model(c);
            Server server = new Server(8000, new ClientHandler(c));
            server.Start();
            Console.ReadKey();
        }
    }
}
