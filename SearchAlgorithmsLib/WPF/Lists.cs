using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WPF
{
    class Lists:List<List_item>
    {
        JArray array;
        public Lists()
        {
            listOfPlayers();
        }

        public int getNumberOfItems()
        {
            return array.Count();
        }

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

        public string ListStart()
        {
            Client myClient = new Client();
            string command = "list";
            string result = myClient.StartSingle(command);
            return result;
        }
    }
}
