using System.Collections.Generic;

namespace JDMallen.CodingExercises.Graphs
{
    public class Node<T>(T payload)
    {
        public List<Node<T>> AdjacencyList { get; set; } = [];

        public T Payload { get; set; } = payload;
    }
}
