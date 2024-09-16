using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDMallen.CodingExercises;

public class Program
{
	public static async Task Main(string[] args)
	{
		await StaticExecutions();
	}

	public static async Task StaticExecutions()
	{
		// FizzBuzz(
		// 	dict: new Dictionary<int, string>
		// 	{
		// 		{ 3, "Fizz" },
		// 		{ 5, "Buzz" },
		// 		{ 4, "Bop" },
		// 		{ 11, "Boobs" }
		// 	});
		//
		// var exercises = new LeetcodeExercises();
		//
		// var result = exercises.Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]);
		//
		// var summary = BenchmarkRunner.Run<CustomExercises>();
		//
		// Console.WriteLine();
		//
		// await ForLoopBreak();

		// var what = Enumerable.Range(1, 10).ToList().Shuffle();


	}

	private static async Task ForLoopBreak()
	{
		for (int i = 0; i < 10; i++)
		{
			await Task.Delay(50);
			for (int j = 0; j < 10; j++)
			{
				Console.WriteLine($"    Inner: {j}");
				await Task.Delay(50);

				break;
			}

			Console.WriteLine($"Outer: {i}");
		}

		Console.WriteLine($"End");
	}
		
	/// <summary>
	/// Adapted from https://stackoverflow.com/a/3319652/3986790
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="originalSet"></param>
	/// <returns></returns>
	public static IEnumerable<IEnumerable<T>> CreateSubsets<T>(IEnumerable<T> originalSet)
	{
		var subsets = new List<T[]>();

		foreach (var t in originalSet)
		{
			var subsetCount = subsets.Count;
			subsets.Add([t]);

			for (var j = 0; j < subsetCount; j++)
			{
				var newSubset = new T[subsets[j].Length + 1];
				subsets[j].CopyTo(newSubset, 0);
				newSubset[^1] = t;
				subsets.Add(newSubset);
			}
		}

		return subsets;
	}

	/// <summary>
	/// Custom FizzBuzz generator/printer.
	/// </summary>
	/// <param name="start">
	/// The start of the range of numbers to print (default: 1).
	/// </param>
	/// <param name="end">
	/// The end of the range of numbers to print (default: 100).
	/// </param>
	/// <param name="dict">
	/// Dictionary of int to string defining the multiples and what keyword
	/// to print when encountered (default: {3, "Fizz"}, {5, "Buzz"}).
	/// </param>
	public static void FizzBuzz(
		int start = 1,
		int end = 100,
		IDictionary<int, string> dict = null)
	{
		dict ??= new Dictionary<int, string>
		{
			{ 3, "Fizz" },
			{ 5, "Buzz" }
		};

		var allCombinations = CreateSubsets(dict);

		for (var i = start; i <= end; i++)
		{
			var numberString = string.Empty;
			var visited = new List<int>();
			foreach (var combination in allCombinations)
			{
				foreach (var kvp in combination)
				{
					if (visited.Contains(kvp.Key) || i % kvp.Key != 0)
						continue;

					numberString += kvp.Value;
					visited.Add(kvp.Key);
				}
			}

			Console.WriteLine(
				string.IsNullOrEmpty(numberString)
					? i.ToString()
					: numberString);
		}
	}
}