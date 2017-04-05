using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /* pseudo code
    1  procedure DFS-iterative(G, v):
2      let S be a stack
3      S.push(v)
4      while S is not empty
5          v = S.pop()
6          if v is not labeled as discovered:
7              label v as discovered
8              for all edges from v to w in G.adjacentEdges(v) do 
9                  S.push(w)*/
    class DFS<T> : ISearcher<T>
    {
        public override Solution<T> search(ISearchable<T> searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            stack.Push(searchable.getInitialState());
            State<T> node;
            while(stack.Count() != 0)
            {
                node = stack.Pop();

                //צריך להוציא את הרשימה הסגורה שבביאףאס החוצה ואז נוכל להשתמש בזה גם פה כי צריך לסמן במה השתמשנו
                //או שנשתמש ברשימה הפתוחה שבסרצר בתור הרשימה הסגורה פה...
            }

        }
    }
}
