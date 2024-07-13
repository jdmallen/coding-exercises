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
			Node<string> entryNode = Graph.GetGraph();
			entryNode.TraverseDfs();
		}
	}
}
