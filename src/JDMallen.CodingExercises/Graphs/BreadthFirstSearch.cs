using System;
using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.Graphs
{
    public class BreadthFirstSearch<T>
    {
        private readonly HashSet<Node<T>> _visited = new();

        public void Traverse(Node<T> node)
        {
            if (node is null)
            {
                return;
            }

            var queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            _visited.Add(node);

            while (queue.TryDequeue(out node))
            {
                Console.Write($"{node.Payload} ");
                foreach (Node<T> adjacentNode in node.AdjacencyList.Where(
                    adjacentNode => !_visited.Contains(adjacentNode)))
                {
                    queue.Enqueue(adjacentNode);
                    _visited.Add(adjacentNode);
                }
            }
        }
    }
}
