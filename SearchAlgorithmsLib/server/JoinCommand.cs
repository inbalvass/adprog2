using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class JoinCommand : ICommand
    {
        private IModel model;

        public JoinCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            string lst = model.JoinCommand(name);
            return lst.ToJSON();
        }
    }
}
