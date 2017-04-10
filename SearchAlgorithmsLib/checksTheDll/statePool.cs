using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace checksTheDll
{
    static class statePool<T>

    {
        static private HashSet<State<T>> pool = new HashSet<State<T>>();
        /*public statePool()
        {
            pool = new List<State<T>>();
        }*/

            //זה עדיין לא ממש נכון כי צריך ליצור כאן את הסטייט ולא לקבל אותו
        static public State<T> getInstance(State<T> current)
        {
            if(!pool.Contains(current))
            {
                pool.Add(current);
                return current;
            }
            else
            {
                return pool.Where(elem => current.Equals(elem)).First();
            }
        }
    }
}
