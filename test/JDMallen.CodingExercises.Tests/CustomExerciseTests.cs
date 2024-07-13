using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests
{
	public class CustomExerciseTests
	{
		private ITestOutputHelper _output;

		public CustomExerciseTests(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void AllSubsetsOfString()
		{
			var str = "ABCDE";
			var exercises = new CustomExercises();
			var actual = exercises.CreateSubsets(str);
			IEnumerable<IEnumerable<char>> list = actual.ToList();
			var count = list.Count();
			_output.WriteLine(
				$"Count: {count} -- " + string.Join("; ", list.Select(s => string.Join(',', s))));
		}

		[Theory]
		[MemberData(nameof(GetPerms))]
		public void PermutationsOfString(string str, HashSet<string> expected)
		{
			var exercises = new CustomExercises();
			var actual = exercises.PermutationsOfString(str);
			var list = actual.ToList();
			var count = list.Count;
			_output.WriteLine($"Count: {count} -- " + string.Join(", ", list));
			Assert.Equal(expected, actual);
		}

		/// <summary>
		/// 0, 1, 1, 2, 3, 5, 8, etc
		/// </summary>
		/// <param name="n"></param>
		/// <param name="expected"></param>
		[Theory]
		[MemberData(nameof(GetPerms))]
		public void PermutationsOfString2(string str, HashSet<string> expected)
		{
			var exercises = new CustomExercises();
			var actual = exercises.PermutationsOfString2(str);
			var list = actual.ToList();
			var count = list.Count;
			_output.WriteLine($"Count: {count} -- " + string.Join(", ", list));
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PermutationsOfString3()
		{
			var exercises = new CustomExercises();
			var actual = exercises.PermutationsOfString3("AAAB");
			var list = actual.ToList();
			var count = list.Count;
			_output.WriteLine($"Count: {count} -- " + string.Join(", ", list));
		}

		public static IEnumerable<object[]> GetPerms()
		{
			yield return new object[] { "A", new HashSet<string> { "A" } };
			yield return new object[]
			{
				"AB",
				new HashSet<string>
				{
					"AB",
					"BA",
				},
			};
			yield return new object[]
			{
				"ABC",
				new HashSet<string>
				{
					"ABC",
					"ACB",
					"BAC",
					"BCA",
					"CBA",
					"CAB",
				},
			};
		}

		/// <summary>
		/// 0, 1, 1, 2, 3, 5, 8, etc
		/// </summary>
		/// <param name="n"></param>
		/// <param name="expected"></param>
		[Theory]
		[InlineData(20, 6765)]

		// [InlineData(0, 0)]
		// [InlineData(1, 1)]
		// [InlineData(3, 2)]
		// [InlineData(6, 8)]
		public void Fib1(int n, int expected)
		{
			var exercises = new CustomExercises();
			var sw = Stopwatch.StartNew();
			var actual = exercises.Fib1(n);
			sw.Stop();
			_output.WriteLine($"{sw.Elapsed.TotalMilliseconds * 1000} us");
			Assert.Equal(expected, actual);
		}

		/// <summary>
		/// 0, 1, 1, 2, 3, 5, 8, etc
		/// </summary>
		/// <param name="n"></param>
		/// <param name="expected"></param>
		[Theory]
		[InlineData(20, 6765)]
		public void Fib2(int n, int expected)
		{
			var exercises = new CustomExercises();
			var sw = Stopwatch.StartNew();
			var actual = exercises.Fib2(n);
			sw.Stop();
			_output.WriteLine($"{sw.Elapsed.TotalMilliseconds * 1000} us");
			Assert.Equal(expected, actual);
		}
	}
}
