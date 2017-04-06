using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    /* pseudo code
     * 
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
        public Solution<T> search(ISearchable<T> searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            HashSet<State<T>> closed = new HashSet<State<T>>();
            stack.Push(searchable.getInitialState());
            State<T> node;
            while(stack.Count != 0)
            {
                node = stack.Pop();
                if (!closed.Contains(node))
                {
                    closed.Add(node);
                    List<State<T>> succerssors = searchable.getAllPossibleStates(node);
                    foreach (State<T> s in succerssors)
                    {
                        stack.Push(s);
                    }
                }
            }
        }
    }
}

/*
 * need to had when it found the goal how it get the path
 * */