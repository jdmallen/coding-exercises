using System.Linq;
using JDMallen.CodingExercises.Graphs;
using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests
{
	public class GraphTests(ITestOutputHelper output)
	{
		[Fact]
		public void TestDfs()
		{
			var graph = Graph.GetSampleGraph();
			graph.AllNodes.Single(n => n.Payload == "A").TraverseDfs();
		}

		[Fact]
		public void TestBfs()
		{
			var graph = Graph.GetSampleGraph();
			graph.AllNodes.Single(n => n.Payload == "A").TraverseBfs();
		}
	}
}
