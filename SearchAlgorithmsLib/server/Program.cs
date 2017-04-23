using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller control = new Controller();
            Model model = new Model(control);
            ClientHandler ch = new ClientHandler(control);
            Server server = new Server(int.Parse(ConfigurationManager.AppSettings["port"]), ch);
            control.setClientHandler(ch);
            control.setModel(model);

            Console.WriteLine("start server");
            server.Start();
            Console.ReadKey();
        }
    }
}
