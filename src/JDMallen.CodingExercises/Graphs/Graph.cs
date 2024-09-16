using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.Graphs;

public class Graph
{
	public HashSet<Node<string>> AllNodes { get; set; } = [];

	public static Graph GetSampleGraph()
	{
		var graph = new Graph();
		graph.Connect("A", "B");
		graph.Connect("A", "C");
		graph.Connect("A", "D");
		graph.Connect("B", "E");
		graph.Connect("C", "E");
		graph.Connect("E", "G");
		graph.Connect("D", "F");
		return graph;
	}

	public void Connect(string payload, string destination)
	{
		// First, generate the string nodes if they don't yet exist

		if (AllNodes.All(n => n.Payload != payload))
		{
			AllNodes.Add(new Node<string>(payload));
		}

		Node<string> fromNode = AllNodes.Single(n => n.Payload == payload);

		if (AllNodes.All(n => n.Payload != destination))
		{
			AllNodes.Add(new Node<string>(destination));
		}

		Node<string> toNode = AllNodes.Single(n => n.Payload == destination);

		// Then connect them

		if (!fromNode.AdjacencyList.Contains(toNode))
		{
			fromNode.AdjacencyList.Add(toNode);
		}

		if (!toNode.AdjacencyList.Contains(fromNode))
		{
			toNode.AdjacencyList.Add(fromNode);
		}
	}
}
