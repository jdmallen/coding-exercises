using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace JDMallen.CodingExercises
{
	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class CustomExercises
	{
		/// <summary>
		/// Adapted from https://stackoverflow.com/a/3319652/3986790
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="originalSet"></param>
		/// <returns></returns>
		public IEnumerable<IEnumerable<T>> CreateSubsets<T>(IEnumerable<T> originalSet)
		{
			var subsets = new List<T[]>();

			foreach (var t in originalSet)
			{
				var subsetCount = subsets.Count;
				subsets.Add(new[] { t });

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

		public HashSet<string> PermutationsOfString(string str)
		{
			return Permute(str, 0, str.Length - 1);
		}

		public HashSet<string> PermutationsOfString2(string str)
		{
			return Permute2(str, 0, str.Length - 1);
		}

		public HashSet<string> PermutationsOfString3(string str)
		{
			return Permute3(str, 0, str.Length - 1);
		}

		private string Exchange(string str, int i, int j)
		{
			char[] arr = str.ToCharArray();
			char temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;

			return new string(arr);
		}

		private HashSet<string> Permute(string str, int left, int right)
		{
			var result = new HashSet<string>();

			if (left == right)
			{
				result.Add(str);
			}
			else
			{
				for (int i = left; i <= right; i++)
				{
					str = Exchange(str, left, i);
					result.UnionWith(Permute(str, left + 1, right));
					str = Exchange(str, left, i);
				}
			}

			return result;
		}

		private HashSet<string> Permute2(string str, int left, int right)
		{
			var result = new HashSet<string>();
			if (right == left)
			{
				result.Add(str);

				return result;
			}

			for (int i = left; i <= right; i++)
			{
				str = Exchange(str, left, i);
				result.UnionWith(Permute2(str, left + 1, right));
				str = Exchange(str, left, i);
			}

			return result;
		}

		private string Swap(string str, int a, int b)
		{
			var arr = str.ToCharArray();

			var temp = arr[a];
			arr[a] = arr[b];
			arr[b] = temp;

			return new string(arr);
		}

		private HashSet<string> Permute3(string str, int left, int right)
		{
			var result = new HashSet<string>();

			if (left == right)
			{
				result.Add(str);

				return result;
			}

			for (int i = left; i < right + 1; i++)
			{
				str = Swap(str, left, i);
				result.UnionWith(Permute3(str, left + 1, right));
				str = Swap(str, left, i);
			}

			return result;
		}

		[Benchmark]
		public int Fib1Bench() => Fib1(100);

		[Benchmark]
		public int Fib2Bench() => Fib2(100);

		public int Fib1(int n)
		{
			if (n == 0)
			{
				return 0;
			}

			if (n == 1)
			{
				return 1;
			}

			return Fib1(n - 1) + Fib1(n - 2);
		}

		private readonly int[] _dp = Enumerable.Repeat(-1, 50).ToArray();

		public int Fib2(int n)
		{
			if (n == 0)
			{
				return 0;
			}

			if (n == 1)
			{
				return 1;
			}

			if (_dp[n] != -1)
			{
				return _dp[n];
			}

			_dp[n] = Fib1(n - 1) + Fib1(n - 2);

			return _dp[n];
		}
	}
}
