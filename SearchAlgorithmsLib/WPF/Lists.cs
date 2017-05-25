using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WPF
{
    /// <summary>
    /// class for the binding of the list of games
    /// </summary>
    class Lists :List<List_item>
    {
        JArray array;
        /// <summary>
        /// constructor
        /// </summary>
        public Lists()
        {
            listOfPlayers();
        }

        /// <summary>
        /// get the number of items in the list
        /// </summary>
        /// <returns></returns>
        public int getNumberOfItems()
        {
            return array.Count();
        }

        /// <summary>
        /// get the name according index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string getName(int index)
        {
            int counter =0;
            foreach (string element in array)
            {
                if(counter != index){
                    counter++;
                }
                else
                {
                    List_item help = new List_item(element);
                    return help.Name;
                }
            }
            return "wrong index";
        }

        /// <summary>
        /// add games to the list
        /// </summary>
        private void listOfPlayers()
        {
            Clear(); //clear the list
            string result = ListStart();
            array = JArray.Parse(result);
            foreach (string element in array)
            { 
                Add(new List_item(element));
            }
        }

        /// <summary>
        /// send message to the server to get the list
        /// </summary>
        /// <returns></returns>
        public string ListStart()
        {
            Client myClient = new Client();
            string command = "list";
            string result = myClient.StartSingle(command);
            return result;
        }
    }
}
