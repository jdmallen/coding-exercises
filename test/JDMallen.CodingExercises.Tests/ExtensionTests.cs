using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests
{
	public class ExtensionTests
	{

		private ITestOutputHelper _output;

		public ExtensionTests(ITestOutputHelper output)
		{
			_output = output;
		}

		[Theory]
		[InlineData("The War OF tHe Rose", "The War of the Rose")]
		[InlineData("at this time i'm not out", "At This Time I'm Not Out")]
		[InlineData("A man wants of nothing but upon", "A Man Wants of Nothing but Upon")]
		[InlineData("as good as it gets", "As Good as It Gets")]
		[InlineData("OUT OF AFRICA", "Out of Africa")]
		public void TitleCase(string str, string expected)
		{
			var actual = str.ToProperTitleCase();
			Assert.Equal(actual, expected);
		}
	}
}
