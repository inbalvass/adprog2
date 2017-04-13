using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace checksTheDll
{
    //אני לא סגורה למה זה צריך להיות סטטי או מה הבעיה עם הפונקציה אז השארתי את זה לך :)
    //תנסי לסיים את זה ואז נראה לי שזה כבר אמור להיות מוכן להתחיל בדיקות על הbfs dfs

    class StatePool<T>

    {
        private HashSet<State<T>> pool;
        public StatePool()
        {
            pool = new HashSet<State<T>>();
        }

            //זה עדיין לא ממש נכון כי צריך ליצור כאן את הסטייט ולא לקבל אותו
        public State<T> getInstance(State<T> current)
        {
            if(!pool.Contains(current))
            {
                pool.Add(current);
                //return current;
                return pool.Where(elem => current.Equals(elem)).First();
            }
            else
            {
                return pool.Where(elem => current.Equals(elem)).First();
            }
        }
    }
}
