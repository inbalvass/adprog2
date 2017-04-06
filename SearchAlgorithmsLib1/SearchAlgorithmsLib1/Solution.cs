using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        public List<State<T>> solution { set; get; }

        public void add(State<T> s)
        {
            solution.Add(s);
        }
    }
}
