using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using JDMallen.CodingExercises.Sorts;
using JDMallen.CodingExercises.Tests.Data;
using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests;

public class SortTests(ITestOutputHelper output)
{
	public static IEnumerable<object[]> StaticIntegerListsMemberData()
	{
		yield return [new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 }];
		yield return [new[] { 9, 4, 7, 8, 1, 3, 5, 10, 2, 6 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }];
	}

	[Theory]
	[MemberData(nameof(StaticIntegerListsMemberData))]
	[ClassData(typeof(DynamicIntegerListsClassData))]
	public void MergeSortIntegers(IList<int> input, IList<int> expected)
	{
		var sorted = input.MergeSort();
		
		// output.WriteLine("Input:    " + string.Join(", ", input));
		// output.WriteLine("Expected: " + string.Join(", ", expected));
		// output.WriteLine("Actual:   " + string.Join(", ", sorted));
		Assert.Equal(expected, sorted);
	}
}
