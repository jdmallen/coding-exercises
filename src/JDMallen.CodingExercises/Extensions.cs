using System.Linq;
using JDMallen.CodingExercises.Graphs;

namespace JDMallen.CodingExercises
{
    public static class Extensions
	{
		public static string ConnectsTo(this string payload, string destination)
		{
			if (Graph.AllNodes.All(n => n.Payload != payload))
			{
				Graph.AllNodes.Add(new Node<string>(payload));
			}

			Node<string> fromNode = Graph.AllNodes.Single(n => n.Payload == payload);

			if (Graph.AllNodes.All(n => n.Payload != destination))
			{
				Graph.AllNodes.Add(new Node<string>(destination));
			}

			Node<string> toNode = Graph.AllNodes.Single(n => n.Payload == destination);
			if (!fromNode.AdjacencyList.Contains(toNode))
			{
				fromNode.AdjacencyList.Add(toNode);
			}

			if (!toNode.AdjacencyList.Contains(fromNode))
			{
				toNode.AdjacencyList.Add(fromNode);
			}

			return destination;
		}

		public static void TraverseDfs<T>(this Node<T> node)
		{
			new DepthFirstSearch<T>().Traverse(node);
		}

		public static void TraverseBfs<T>(this Node<T> node)
		{
			new BreadthFirstSearch<T>().Traverse(node);
		}

		public static void AddAdjacentNode<T>(this Node<T> node, Node<T> adjacentNode)
		{
			node.AdjacencyList.Add(adjacentNode);
		}
	}
}
