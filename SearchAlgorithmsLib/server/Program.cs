using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    /// <summary>
    /// start the server 
    /// </summary>
    class Program
    {
        /// <summary>
        /// start the server
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Controller control = new Controller();
            Model model = new Model(control);
            ClientHandler ch = new ClientHandler(control);
            Server server = new Server(8000, ch);
            control.setClientHandler(ch);
            control.setModel(model);

            server.Start();
            Console.ReadKey();
        }
    }
}
