using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        private List<State<T>> solution { get; }

        public Solution()
        {
            solution = new List<State<T>>();
        }

        public void add(State<T> s)
        {
            solution.Add(s);
        }
    }
}
