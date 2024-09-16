using System.Linq;
using JDMallen.CodingExercises.Graphs;

namespace JDMallen.CodingExercises;

public static class Extensions
{
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