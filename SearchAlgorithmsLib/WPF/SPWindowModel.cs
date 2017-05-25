using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF
{
    /// <summary>
    /// the model class for the single player window.
    /// </summary>
    class SPWindowModel 
    {
        private Client myClient;
        private string _mazeStr;

        /// <summary>
        /// the mazeStr property
        /// </summary>
        public string mazeStr
        {
            get
            {
                return _mazeStr;
            }
            set
            {
                this._mazeStr = value;

            }
        }

        public SPWindowModel()
        {
            
        }

        /// <summary>
        /// sending a request to generate a new maze.
        /// </summary>
        /// <param name="name"> the name of the maze.</param>
        /// <param name="row">the number of rows</param>
        /// <param name="col">the number of columns</param>
        public void generate(string name,int row,int col)
        {
            myClient = new Client();
            string command = "generate " + name + " " + row + " " + col;
            this.mazeStr = myClient.StartSingle(command);
   
        }

        /// <summary>
        /// sending a request of solving the maze.
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <returns></returns>
        public string solve(string name)
        {
            myClient = new Client();
            string command = "solve " + name + " " + Properties.Settings.Default.DefAlgo;
            return myClient.StartSingle(command);
        }
    }
}
