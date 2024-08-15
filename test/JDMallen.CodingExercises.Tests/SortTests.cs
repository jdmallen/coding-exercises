using System.Collections.Generic;
using JDMallen.CodingExercises.Sorts;
using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests;

public class SortTests(ITestOutputHelper output)
{
	[Theory]
	[InlineData(new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 })]
	[InlineData(new[] { 9, 4, 7, 8, 1, 3, 5, 10, 2, 6 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
	public void MergeSort(IList<int> input, IList<int> expected)
	{
		var sorted = input.MergeSort();
		Assert.Equal(expected, sorted);
	}
}
