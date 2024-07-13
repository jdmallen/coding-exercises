using System;
using System.Collections.Generic;

namespace JDMallen.CodingExercises.Graphs
{
    public class DepthFirstSearch<T>
    {
        private readonly HashSet<Node<T>> _visited = new();

        public void Traverse(Node<T> node)
        {
            if (node == null || _visited.Contains(node))
            {
                return;
            }

            Console.Write($"{node.Payload} ");

            _visited.Add(node);
            node.AdjacencyList.ForEach(Traverse);
        }
    }
}
