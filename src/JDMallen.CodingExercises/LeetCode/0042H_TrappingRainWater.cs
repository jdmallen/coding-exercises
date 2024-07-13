using BenchmarkDotNet.Attributes;

namespace JDMallen.CodingExercises.LeetCode;

public class TrappingRainWater
{
	[Benchmark]
	public int TrapTest1() => Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });

	[Benchmark]
	public int TrapTest2() => TrapTake2(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });

	[Benchmark]
	public int TrapTest3() => TrapTake3(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });

	public int Trap(int[] height)
	{
		var unitsCollected = 0;
		int len = height.Length;

		if (len < 3)
		{
			// Need at least 3 columns, with the outer two being taller than the middle, to store any rain.
			return 0;
		}

		var maxHeight = 0;
		for (var i = 0; i < len; i++)
		{
			int current = height[i];
			if (current > maxHeight)
			{
				maxHeight = current;
			}
		}

		var arr = new char[len, maxHeight];
		for (var i = 0; i < len; i++)
		{
			for (var j = 0; j < height[i]; j++)
			{
				arr[i, j] = 'X';
			}
		}

		// // Print for visuals, top-down
		// for (int j = maxHeight-1; j >= 0; j--)
		// {
		// 	for (int i = 0; i < len; i++)
		// 	{
		// 		Console.Write(arr[i, j] == 0 ? ' ' : arr[i, j]);
		// 	}
		// 	Console.WriteLine();
		// }

		// Row by row, top-down
		for (int j = maxHeight - 1; j >= 0; j--)
		{
			int lastBlock = -1;
			for (var i = 0; i < len; i++)
			{
				if (arr[i, j] != 'X')
				{
					continue;
				}

				if (lastBlock != -1 && i - lastBlock != 1)
				{
					unitsCollected += i - lastBlock - 1;
				}

				lastBlock = i;
			}
		}

		return unitsCollected;
	}

	public int TrapTake2(int[] height)
	{
		var unitsCollected = 0;
		int len = height.Length;

		if (len < 3)
		{
			// Need at least 3 columns, with the outer two being taller than the middle, to store any rain.
			return 0;
		}

		var maxHeight = 0;
		for (var i = 0; i < len; i++)
		{
			int current = height[i];
			if (current > maxHeight)
			{
				maxHeight = current;
			}
		}

		// Row by row, top-down
		for (int j = maxHeight - 1; j >= 0; j--)
		{
			int lastBlock = -1;
			for (var i = 0; i < len; i++)
			{
				int h = height[i];
				if (h < j + 1)
				{
					continue;
				}

				if (lastBlock != -1 && i - lastBlock != 1)
				{
					unitsCollected += i - lastBlock - 1;
				}

				lastBlock = i;
			}
		}

		return unitsCollected;
	}

	public int TrapTake3(int[] height)
	{
		var unitsCollected = 0;
		int len = height.Length;

		if (len < 3)
		{
			// Need at least 3 columns, with the outer two being taller than the middle, to store any rain.
			return 0;
		}

		var maxHeightsFromLeft = new int[len];
		var maxHeight = 0;
		for (var i = 0; i < len; i++)
		{
			int current = height[i];
			if (current > maxHeight)
			{
				maxHeight = current;
			}

			maxHeightsFromLeft[i] = maxHeight;
		}

		maxHeight = 0;
		var maxHeightsFromRight = new int[len];
		for (int i = len - 1; i >= 0; i--)
		{
			int current = height[i];
			if (current > maxHeight)
			{
				maxHeight = current;
			}

			maxHeightsFromRight[i] = maxHeight;
		}

		for (var i = 0; i < len; i++)
		{
			unitsCollected +=
				(maxHeightsFromRight[i] <= maxHeightsFromLeft[i]
					? maxHeightsFromRight[i]
					: maxHeightsFromLeft[i])
				- height[i];
		}

		return unitsCollected;
	}
}
