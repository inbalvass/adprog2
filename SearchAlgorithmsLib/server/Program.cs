using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
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

            int port = Int32.Parse(ConfigurationManager.AppSettings["port"]);
            Server server = new Server(port, ch);
            control.setClientHandler(ch);
            control.setModel(model);

            server.Start();
            Console.ReadKey();
        }
    }
}
