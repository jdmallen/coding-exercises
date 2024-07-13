using JDMallen.CodingExercises.Codility;
using Xunit;
using Xunit.Abstractions;

namespace JDMallen.CodingExercises.Tests;

public class CodilityExerciseTests(ITestOutputHelper output)
{
	[Theory]
	[InlineData(1041, 5)]
	[InlineData(32, 0)]
	[InlineData(15, 0)]
	[InlineData(3128, 4)]
	[InlineData(1340, 2)]
	[InlineData(234, 1)]
	[InlineData(8345, 5)]
	[InlineData(89283456, 2)]
	[InlineData(23548, 1)]
	[InlineData(782345, 8)]
	public void BinaryGap(int input, int expected)
	{
		var exercises = new L1E_BinaryGap();
		int actual = exercises.BinaryGap(input);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new[]{3, 8, 9, 7, 6}, 3, new[]{9, 7, 6, 3, 8})]
	[InlineData(new[]{0, 0, 0}, 1, new[]{0, 0, 0})]
	[InlineData(new[]{1, 2, 3, 4}, 4, new[]{1, 2, 3, 4})]
	public void ArrayRotation(int[] a, int k, int[] expected)
	{
		var exercises = new L2E_CyclicRotation();
		var actual = exercises.ArrayRotation(a, k);
		Assert.Equal(expected, actual);
	}
}
