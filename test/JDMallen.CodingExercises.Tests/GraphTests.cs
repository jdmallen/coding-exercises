using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests
{
	public class GraphTests
	{

		private ITestOutputHelper _output;

		public GraphTests(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void TestDfs()
		{
			var entryNode = Graph.GetGraph();
			entryNode.TraverseDfs();
		}
	}
}
