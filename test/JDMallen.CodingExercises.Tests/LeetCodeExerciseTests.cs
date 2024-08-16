using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using JDMallen.CodingExercises.LeetCode;
using JDMallen.CodingExercises.LeetCode.Shared;
using Xunit;
using Xunit.Abstractions;
using ReverseLinkedList = JDMallen.CodingExercises.LeetCode.ReverseLinkedList;

namespace JDMallen.CodingExercises.Tests
{
	public class LeetCodeExerciseTests(ITestOutputHelper output)
	{
		[Theory]
		[InlineData("12121", 8)]
		[InlineData("2101", 1)]
		[InlineData("27", 1)]
		[InlineData("10", 1)]
		[InlineData("12", 2)]
		[InlineData("226", 3)]
		[InlineData("0", 0)]
		[InlineData("06", 0)]
		[InlineData("10011", 0)]
		public void DecodeWays(string str, int expected)
		{
			var exercises = new DecodeWays();
			int actual = exercises.NumDecodings(str);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetListsToReverse()
		{
			yield return
			[
				new ListNode(
					1,
					new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
				new ListNode(
					5,
					new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1))))),
			];
			yield return
			[
				new ListNode(1, new ListNode(2)), new ListNode(2, new ListNode(1)),
			];
			yield return [new ListNode(1), new ListNode(1)];
			yield return [null, null];
		}

		[Theory]
		[MemberData(nameof(GetListsToReverse))]
		public void ReverseList(ListNode head, ListNode expected)
		{
			var exercises = new ReverseLinkedList();
			var actual = exercises.ReverseList(head);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
		[InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
		[InlineData(new[] { 2, 1, 2, 0, 1 }, 1)]
		[InlineData(new[] { 2, 4, 1 }, 2)]
		public void MaxProfit(int[] prices, int expected)
		{
			var exercises = new BestTimeToBuyAndSellStock();
			int actual = exercises.MaxProfit(prices);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void WebCrawler()
		{
			var exercises = new WebCrawlerMultithreaded();
			HashSet<string> actual = exercises.Crawl(
					"http://news.yahoo.com/news/topics/",
					new WebCrawlerMultithreaded.HtmlParser())
				.ToHashSet();
			var expected = new HashSet<string>()
			{
				"http://news.yahoo.com",
				"http://news.yahoo.com/news",
				"http://news.yahoo.com/news/topics/",
				"http://news.yahoo.com/us"
			};
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetWords()
		{
			yield return
			[
				new[] { "This", "is", "an", "example", "of", "text", "justification." },
				16,
				new List<string>
				{
					"This    is    an",
					"example  of text",
					"justification.  ",
				},
			];
			yield return
			[
				new[] { "What", "must", "be", "acknowledgment", "shall", "be" },
				16,
				new List<string>
				{
					"What   must   be",
					"acknowledgment  ",
					"shall be        ",
				},
			];
			yield return
			[
				new[]
				{
					"Science",
					"is",
					"what",
					"we",
					"understand",
					"well",
					"enough",
					"to",
					"explain",
					"to",
					"a",
					"computer.",
					"Art",
					"is",
					"everything",
					"else",
					"we",
					"do"
				},
				20,
				new List<string>
				{
					"Science  is  what we",
					"understand      well",
					"enough to explain to",
					"a  computer.  Art is",
					"everything  else  we",
					"do                  ",
				},
			];
			yield return
			[
				new[]
				{
					"ask",
					"not",
					"what",
					"your",
					"country",
					"can",
					"do",
					"for",
					"you",
					"ask",
					"what",
					"you",
					"can",
					"do",
					"for",
					"your",
					"country",
				},
				16,
				new List<string>
				{
					"ask   not   what",
					"your country can",
					"do  for  you ask",
					"what  you can do",
					"for your country",
				},
			];

			yield return
			[
				new[]
				{
					"When",
					"I",
					"was",
					"just",
					"a",
					"little",
					"girl",
					"I",
					"asked",
					"my",
					"mother",
					"what",
					"will",
					"I",
					"be",
					"Will",
					"I",
					"be",
					"pretty",
					"Will",
					"I",
					"be",
					"rich",
					"Here's",
					"what",
					"she",
					"said",
					"to",
					"me",
					"Que",
					"sera",
					"sera",
					"Whatever",
					"will",
					"be",
					"will",
					"be",
					"The",
					"future's",
					"not",
					"ours",
					"to",
					"see",
					"Que",
					"sera",
					"sera",
					"When",
					"I",
					"was",
					"just",
					"a",
					"child",
					"in",
					"school",
					"I",
					"asked",
					"my",
					"teacher",
					"what",
					"should",
					"I",
					"try",
					"Should",
					"I",
					"paint",
					"pictures",
					"Should",
					"I",
					"sing",
					"songs",
					"This",
					"was",
					"her",
					"wise",
					"reply",
					"Que",
					"sera",
					"sera",
					"Whatever",
					"will",
					"be",
					"will",
					"be",
					"The",
					"future's",
					"not",
					"ours",
					"to",
					"see",
					"Que",
					"sera",
					"sera",
					"When",
					"I",
					"grew",
					"up",
					"and",
					"fell",
					"in",
					"love",
					"I",
					"asked",
					"my",
					"sweetheart",
					"what",
					"lies",
					"ahead",
					"Will",
					"there",
					"be",
					"rainbows",
					"day",
					"after",
					"day",
					"Here's",
					"what",
					"my",
					"sweetheart",
					"said",
					"Que",
					"sera",
					"sera",
					"Whatever",
					"will",
					"be",
					"will",
					"be",
					"The",
					"future's",
					"not",
					"ours",
					"to",
					"see",
					"Que",
					"sera",
					"sera",
					"What",
					"will",
					"be,",
					"will",
					"be",
					"Que",
					"sera",
					"sera...",
				},
				60,
				new List<string>
				{
					"When  I was just a little girl I asked my mother what will I",
					"be  Will  I be pretty Will I be rich Here's what she said to",
					"me  Que  sera sera Whatever will be will be The future's not",
					"ours  to see Que sera sera When I was just a child in school",
					"I asked my teacher what should I try Should I paint pictures",
					"Should  I  sing  songs This was her wise reply Que sera sera",
					"Whatever  will  be  will be The future's not ours to see Que",
					"sera  sera  When  I  grew  up  and  fell  in love I asked my",
					"sweetheart  what lies ahead Will there be rainbows day after",
					"day  Here's  what  my sweetheart said Que sera sera Whatever",
					"will  be  will be The future's not ours to see Que sera sera",
					"What will be, will be Que sera sera...                      ",
				},
			];
		}

		[Theory]
		[MemberData(nameof(GetWords))]
		public void FullJustify(string[] words, int maxWidth, IList<string> expected)
		{
			var exercises = new TextJustification();
			IList<string> actual = exercises.FullJustify(words, maxWidth);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetIntervals()
		{
			yield return
			[
				new int[][] { [1, 3], [2, 6], [8, 10], [15, 18], },
				new int[][] { [1, 6], [8, 10], [15, 18] },
			];
			yield return
			[
				new int[][] { [1, 4], [4, 5] },
				new int[][] { [1, 5] },
			];
			yield return
			[
				new int[][] { [2, 3], [4, 5], [6, 7], [8, 9], [1, 10], },
				new int[][] { [1, 10] },
			];
			yield return
			[
				new int[][] { [1, 4], [2, 3] },
				new int[][] { [1, 4] },
			];
			yield return
			[
				new int[][] { [2, 3], [4, 6], [5, 7], [3, 4], },
				new int[][] { [2, 7] },
			];
		}

		[Theory]
		[MemberData(nameof(GetIntervals))]
		public void MergeIntervals(int[][] intervals, int[][] expected)
		{
			var exercises = new MergeIntervals();
			int[][] actual = exercises.Merge(intervals);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetIslands()
		{
			yield return
			[
				new char[][]
				{
					//      j ==  0    1    2    3    4
					['1', '1', '0', '0', '0'], // i == 0
					['1', '1', '0', '0', '0'], // i == 1
					['0', '0', '1', '0', '0'], // i == 2
					['0', '0', '0', '1', '1'], // i == 3
				},
				3,
			];
			yield return
			[
				new char[][]
				{
					//      j ==  0    1    2    3    4
					['1', '1', '1', '1', '0'], // i == 0
					['1', '1', '0', '1', '0'], // i == 1
					['1', '1', '0', '0', '0'], // i == 2
					['0', '0', '0', '0', '0'], // i == 3
				},
				1,
			];
			yield return
			[
				new char[][] { ['1', '0'], ['0', '1'] }, 2,
			];
			yield return
			[
				new char[][]
				{
					//  j ==      0    1    2
					['1', '0', '1'], // i == 0
					['1', '1', '0'], // i == 1
					['0', '0', '1'], // i == 2
				},
				3,
			];
			yield return
			[
				new char[][]
				{
					//  j ==      0    1    2
					['1', '0', '3'], // i == 0
					['4', '5', '0'], // i == 1
					['0', '0', '9'], // i == 2
				},
				3,
			];
		}

		[Theory]
		[MemberData(nameof(GetIslands))]
		public void NumIslands(char[][] grid, int expected)
		{
			var exercises = new NumberOfIslands();
			int actual = exercises.NumIslands(grid);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
		[InlineData(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
		[InlineData(new[] { 2, 0, 2 }, 2)]
		public void WaterTrap(int[] heights, int expected)
		{
			var exercises = new TrappingRainWater();
			int actual = exercises.Trap(heights);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
		[InlineData(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
		[InlineData(new[] { 2, 0, 2 }, 2)]
		public void WaterTrapTake2(int[] heights, int expected)
		{
			var exercises = new TrappingRainWater();
			int actual = exercises.TrapTake2(heights);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
		[InlineData(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
		[InlineData(new[] { 2, 0, 2 }, 2)]
		public void WaterTrapTake3(int[] heights, int expected)
		{
			var exercises = new TrappingRainWater();
			int actual = exercises.TrapTake3(heights);
			Assert.Equal(expected, actual);
		}

		[Theory]                              // Ratios of Gos to Turns
		[InlineData("GLRLLGLL", true)]        // 1:2
		[InlineData("GLRLLGRR", true)]        // 1:2
		[InlineData("GGLLGG", true)]          // 2:1
		[InlineData("GG", false)]             // 2:0
		[InlineData("GL", true)]              // 1:1
		[InlineData("GLGLGGLGL", false)]      // 5:4
		[InlineData("LRRRRLLLRL", true)]      // 0:0
		[InlineData("GLRLGLLGLGRGLGL", true)] // 0:0
		public void IsRobotBounded(string instructions, bool expected)
		{
			var exercises = new RobotBoundedInCircle();
			bool actual = exercises.IsRobotBounded(instructions);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetNumbers()
		{
			yield return
			[
				new ListNode(1, new ListNode(8, new ListNode(9))),
				new ListNode(6, new ListNode(4, new ListNode(8))),
				new ListNode(7, new ListNode(2, new ListNode(8, new ListNode(1)))),
			];
			yield return
			[
				new ListNode(
					9,
					new ListNode(
						9,
						new ListNode(
							9,
							new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
				new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
				new ListNode(
					8,
					new ListNode(
						9,
						new ListNode(
							9,
							new ListNode(
								9,
								new ListNode(
									0,
									new ListNode(0, new ListNode(0, new ListNode(1)))))))),
			];
		}

		[Theory]
		[MemberData(nameof(GetNumbers))]
		public void AddTwoNumbers(ListNode num1, ListNode num2, ListNode expected)
		{
			var exercises = new Add2Numbers();
			var result = exercises.AddTwoNumbers(num1, num2);
			bool match = true;
			var ans1 = result;
			var ans2 = expected;
			while (ans1 != null && ans2 != null)
			{
				match &= ans1.val == ans2.val;
				ans1 = ans1.next;
				ans2 = ans2.next;
			}

			Assert.True(match);
		}

		[Theory]
		[InlineData("42", 42)]
		[InlineData("   -42", -42)]
		[InlineData("4193 with words", 4193)]
		[InlineData("words and 987", 0)]
		[InlineData("-91283472332", -2147483648)]
		[InlineData("3.14159", 3)]
		[InlineData("+-12", 0)]
		public void StringToInt(string s, int expected)
		{
			var exercises = new StringToIntegerAtoi();
			int result = exercises.MyAtoi(s);
			Assert.Equal(expected, result);
		}

		[Fact]
		public void LruCacheDt1()
		{
			//["LRUCache","put","put","get","put","get","put","get","get","get"]
			//[[2],       [1,1],[2,2],[1],  [3,0],[2],  [4,4],[1],  [3],  [4]]
			LRUCacheDateTime lRuCacheDateTime = new LRUCacheDateTime(2);
			lRuCacheDateTime.Put(1, 1);         // cache is {1=1}
			lRuCacheDateTime.Put(2, 2);         // cache is {1=1, 2=2}
			int get1 = lRuCacheDateTime.Get(1); // return 1
			Assert.Equal(1, get1);
			lRuCacheDateTime.Put(3, 0);         // LRU key was 2, evicts key 2, cache is {1=1, 3=0}
			int get2 = lRuCacheDateTime.Get(2); // returns -1 (not found)
			Assert.Equal(-1, get2);
			lRuCacheDateTime.Put(4, 4);         // LRU key was 1, evicts key 1, cache is {4=4, 3=0}
			int get3 = lRuCacheDateTime.Get(1); // return -1 (not found)
			Assert.Equal(-1, get3);
			int get4 = lRuCacheDateTime.Get(3); // return 3
			Assert.Equal(0, get4);
			int get5 = lRuCacheDateTime.Get(4); // return 4
			Assert.Equal(4, get5);
		}

		[Fact]
		public void LruCacheDt2()
		{
			//["LRUCache","put","put","get","put","get","get"]
			//[[2],       [2,1],[1,1], [2], [4,1], [1],  [2]]
			LRUCacheDateTime lruCacheDateTime = new LRUCacheDateTime(2);
			lruCacheDateTime.Put(2, 1);         // cache is {2=1}
			lruCacheDateTime.Put(1, 1);         // cache is {2=1, 1=1}
			int get1 = lruCacheDateTime.Get(2); // return 1
			Assert.Equal(1, get1);
			lruCacheDateTime.Put(4, 1);         // LRU key was 1, evicts key 1, cache is {2=1, 4=1}
			int get2 = lruCacheDateTime.Get(1); // return -1 (not found)
			Assert.Equal(-1, get2);
			int get3 = lruCacheDateTime.Get(2); // return 1 (found)
			Assert.Equal(1, get3);
		}

		[Fact]
		public async Task LruCacheDt2Loop()
		{
			Action cacheLoop = () =>
			{
				for (var i = 0; i < 100000; i++)
				{
					if (i % 10000 == 0)
					{
						output.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Loop #{i}");
					}

					LruCacheDt2();
				}

				// return Task.CompletedTask;
			};

			IEnumerable<Task> tasks =
				Enumerable.Range(0, 64).Select(_ => Task.Factory.StartNew(cacheLoop));
			await Task.WhenAll(tasks);
		}

		[Fact]
		public void LruCache1()
		{
			//["LRUCache","put","put","get","put","get","put","get","get","get"]
			//[[2],       [1,1],[2,2],[1],  [3,0],[2],  [4,4],[1],  [3],  [4]]
			LRUCacheLoop lruCache = new LRUCacheLoop(2);
			lruCache.Put(1, 1);         // cache is {1=1}
			lruCache.Put(2, 2);         // cache is {1=1, 2=2}
			int get1 = lruCache.Get(1); // return 1
			Assert.Equal(1, get1);
			lruCache.Put(3, 0);         // LRU key was 2, evicts key 2, cache is {1=1, 3=0}
			int get2 = lruCache.Get(2); // returns -1 (not found)
			Assert.Equal(-1, get2);
			lruCache.Put(4, 4);         // LRU key was 1, evicts key 1, cache is {4=4, 3=0}
			int get3 = lruCache.Get(1); // return -1 (not found)
			Assert.Equal(-1, get3);
			int get4 = lruCache.Get(3); // return 3
			Assert.Equal(0, get4);
			int get5 = lruCache.Get(4); // return 4
			Assert.Equal(4, get5);
		}

		[Fact]
		public void LruCache2()
		{
			//["LRUCache","put","put","get","put","get","get"]
			//[[2],       [2,1],[1,1], [2], [4,1], [1],  [2]]
			LRUCacheLoop lruCache = new LRUCacheLoop(2);
			lruCache.Put(2, 1);         // cache is {2=1}
			lruCache.Put(1, 1);         // cache is {2=1, 1=1}
			int get1 = lruCache.Get(2); // return 1
			Assert.Equal(1, get1);
			lruCache.Put(4, 1);         // LRU key was 1, evicts key 1, cache is {2=1, 4=1}
			int get2 = lruCache.Get(1); // return -1 (not found)
			Assert.Equal(-1, get2);
			int get3 = lruCache.Get(2); // return 1 (found)
			Assert.Equal(1, get3);
		}

		[Fact]
		public void LruCache3()
		{
			// ["LRUCache","get","put","get","put","put","get","get"]
			// [[2],       [2],  [2,6],[1],  [1,5],[1,2],[1],  [2]]

			LRUCacheLoop lruCache = new LRUCacheLoop(2);
			int get1 = lruCache.Get(2); // return -1
			Assert.Equal(-1, get1);
			lruCache.Put(2, 6);         // cache is {2=6}
			int get2 = lruCache.Get(1); // return -1
			Assert.Equal(-1, get2);
			lruCache.Put(1, 5);         // cache is {2=6, 1=5}
			lruCache.Put(1, 2);         // overwrites key 1, cache is {2=6, 1=2}
			int get3 = lruCache.Get(1); // return 2
			Assert.Equal(2, get3);
			int get4 = lruCache.Get(2); // return 6
			Assert.Equal(6, get4);
		}

		[Fact]
		public void LruCache4()
		{
			// ["LRUCache","put","put","get","put","get","get"]
			// [[2],       [2,1],[1,1],[2],  [4,1],[1],  [2]] 

			LRUCache lruCache = new(2);
			lruCache.Put(2, 1);         // cache is {2=1}
			lruCache.Put(1, 1);         // cache is {2=1, 1=1}
			int get1 = lruCache.Get(2); // return 1
			Assert.Equal(1, get1);
			lruCache.Put(4, 1);         // LRU key was 1, evicts key 1, cache is {2=1, 4=1}
			int get2 = lruCache.Get(1); // returns -1 (not found)
			Assert.Equal(-1, get2);
			int get3 = lruCache.Get(2); // return 1
			Assert.Equal(1, get3);
		}

		[Fact]
		public void LruCache5()
		{
			//["LRUCache","put","get"]
			//[[1],[2,1],[2]]

			LRUCache lruCache = new(1);
			lruCache.Put(2, 1);         // cache is {1=1}
			int get1 = lruCache.Get(2); // return 1
			Assert.Equal(1, get1);
		}

		[Fact]
		public void LruCache6()
		{
			//["LRUCache","put","get"]
			//[[1],[2,1],[2]]

			LRUCache lruCache = new(1);
			lruCache.Put(2, 1);         // cache is {1=1}
			int get1 = lruCache.Get(2); // return 1
			Assert.Equal(1, get1);
		}

		[Theory]
		[InlineData("\"LRUCache\",\"put\",\"get\"", "[[1],[2,1],[2]]", "[null,null,1]")]
		[InlineData(
			"\"LRUCache\",\"put\",\"put\",\"get\",\"put\",\"get\",\"put\",\"get\",\"get\",\"get\"",
			"[[2],       [1,1],[2,2],[1],  [3,0],[2],  [4,4],[1],  [3],  [4]]",
			"[null,null,null,1,null,-1,null,-1,0,4]")]
		[InlineData(
			"\"LRUCache\",\"put\",\"get\",\"put\",\"get\",\"get\"",
			"[[1],[2,1],[2],[3,2],[2],[3]]",
			"[null,null,1,null,-1,2]")]
		[InlineData(
			"\"LRUCache\",\"put\",\"put\",\"get\",\"put\",\"get\",\"get\"",
			"[[2],[2,1],[1,1],[2],[4,1],[1],[2]]",
			"[null,null,null,1,null,-1,1]")]
		[InlineData(
			"[\"LRUCache\",\"put\",\"put\",\"get\",\"put\",\"put\",\"get\"]",
			"[[2],[2,1],[2,2],[2],[1,1],[4,1],[2]]",
			"[null,null,null,2,null,null,-1]")]
		[InlineData(
			"[\"LRUCache\",\"get\",\"get\",\"put\",\"get\",\"put\",\"put\",\"put\",\"put\",\"get\",\"put\"]",
			"[[1],[6],[8],[12,1],[2],[15,11],[5,2],[1,15],[4,2],[5],[15,15]]",
			"[null,-1,-1,null,-1,null,null,null,null,-1,null]")]
		public void LruCacheParse(string operations, string values, string expecteds)
		{
			operations = operations.Replace("\"", "");
			values = values.Replace(" ", "");
			expecteds = expecteds.Replace(" ", "");
			string[] ops = operations.Split(
				new[] { '[', ']', ',' },
				StringSplitOptions.RemoveEmptyEntries);
			string[] vals = values.Split(new[] { ']' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(
					x =>
					{
						Debug.WriteLine("poop");
						var match = Regex.Match(x, @"[\[\,]*(\d+\,?\-?\d*)");

						return match.Groups.Count >= 2
							? match.Groups[1].Value
							: match.Groups[0].Value;
					})
				.ToArray();
			string[] exps = expecteds.Split(
				new[] { '[', ']', ',' },
				StringSplitOptions.RemoveEmptyEntries);

			Assert.Equal(ops.Length, vals.Length);
			Assert.Equal(ops.Length, exps.Length);

			var cache = new LRUCache(int.Parse(vals[0]));

			for (var i = 1; i < ops.Length; i++)
			{
				string op = ops[i];
				string val = vals[i];
				string exp = exps[i];
				switch (op)
				{
					case "put":
						string[] parts = val.Split(',');
						int key = int.Parse(parts[0]);
						int value = int.Parse(parts[1]);
						cache.Put(key, value);

						break;
					case "get":
						int lookupKey = int.Parse(val);
						bool expectedVal = int.TryParse(exp, out int expected);
						Assert.True(expectedVal);
						int getVal = cache.Get(lookupKey);
						Assert.Equal(expected, getVal);

						break;
				}
			}
		}

		[Theory]
		[InlineData("444947137", "7449447")]
		[InlineData("00009", "9")]
		[InlineData("0000000000000000000000000000000000000000000", "0")]
		public void LargestPalindromic(string input, string expected)
		{
			var exercises = new LargestPalindromicNumber();
			string actual = exercises.LargestPalindromic(input);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(26, 1, 3)]
		[InlineData(54, 2, 4)]
		[InlineData(25, 30, 5)]
		[InlineData(3, 1, 2)]
		[InlineData(4, 2, 2)]
		[InlineData(5, 3, 2)]
		public void MinimumOperationsToMakeEqual(int x, int y, int expected)
		{
			var exercises = new MinimumNumberOfOperationsToMakeXAndYEqual();
			int actual = exercises.MinimumOperationsToMakeEqual(x, y);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(
			"[\"TicTacToe\", \"move\", \"move\", \"move\", \"move\", \"move\", \"move\", \"move\"]",
			"[[3], [0, 0, 1], [0, 2, 2], [2, 2, 1], [1, 1, 2], [2, 0, 1], [1, 0, 2], [2, 1, 1]]",
			"[null, 0, 0, 0, 0, 0, 0, 1]")]
		[InlineData(
			"[\"TicTacToe\",\"move\",\"move\",\"move\"]",
			"[[2],[0,0,2],[0,1,1],[1,1,2]]",
			"[null,0,0,2]")]
		[InlineData(
			"[\"TicTacToe\",\"move\",\"move\",\"move\"]",
			"[[2],[0,1,1],[1,1,2],[1,0,1]]",
			"[null,0,0,1]")]
		[InlineData(
			"[\"TicTacToe\",\"move\",\"move\",\"move\",\"move\",\"move\",\"move\",\"move\"]",
			"[[4],[0,3,1],[3,3,2],[3,0,1],[0,0,2],[2,1,1],[2,2,2],[1,2,1]]",
			"[null,0,0,0,0,0,0,1]")]
		[InlineData(
			"[\"TicTacToe\",\"move\",\"move\",\"move\",\"move\",\"move\",\"move\",\"move\",\"move\",\"move\"]",
			"[[3],[2,1,1],[1,2,2],[0,2,1],[2,2,2],[0,1,1],[0,0,2],[2,0,1],[1,0,2],[1,1,1]]",
			"[null,0,0,0,0,0,0,0,0,1]")]
		public void TicTacToe(string operations, string values, string expecteds)
		{
			operations = operations.Replace("\"", "");
			operations = operations.Replace(" ", "");
			values = values.Replace(" ", "");
			expecteds = expecteds.Replace(" ", "");
			string[] ops = operations.Split(
				new[] { '[', ']', ',' },
				StringSplitOptions.RemoveEmptyEntries);
			string[] vals = values.Split(new[] { ']' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(
					x =>
					{
						var match = Regex.Match(x, @"[\[\,]*(\d+\,?\d?\,?\d?)");

						return match.Groups.Count >= 2
							? match.Groups[1].Value
							: match.Groups[0].Value;
					})
				.ToArray();
			string[] exps = expecteds.Split(
				new[] { '[', ']', ',' },
				StringSplitOptions.RemoveEmptyEntries);

			Assert.Equal(ops.Length, vals.Length);
			Assert.Equal(ops.Length, exps.Length);

			var game = new TicTacToe(int.Parse(vals[0]));

			for (var i = 1; i < ops.Length; i++)
			{
				// string op = ops[i]; // always "move"
				string val = vals[i];
				int expected = int.Parse(exps[i]);

				string[] parts = val.Split(',');
				int row = int.Parse(parts[0]);
				int col = int.Parse(parts[1]);
				int player = int.Parse(parts[2]);

				var actual = game.Move(row, col, player);
				Assert.Equal(actual, expected);
			}
		}

		[Theory]
		[InlineData(new[] { 0, 0 }, "0")]
		[InlineData(new[] { 10, 2 }, "210")]
		[InlineData(new[] { 3, 30, 34, 5, 9 }, "9534330")]
		[InlineData(new[] { 999999991, 9 }, "9999999991")]
		[InlineData(new[] { 1000000000, 1000000000 }, "10000000001000000000")]
		public void LargestNumber(int[] input, string expected)
		{
			var exercises = new LargestNumberFormedFromIntegers();
			string actual = exercises.LargestNumber(input);
			Assert.Equal(expected, actual);
		}

		//RankTeams(string[] votes)
		[Theory]
		[InlineData(new[] { "ABC", "ACB", "ABC", "ACB", "ACB" }, "ACB")]
		[InlineData(new[] { "WXYZ", "XYZW" }, "XWYZ")]
		[InlineData(new[] { "ZMNAGUEDSJYLBOPHRQICWFXTVK" }, "ZMNAGUEDSJYLBOPHRQICWFXTVK")]
		[InlineData(
			new[]
			{
				"FVSHJIEMNGYPTQOURLWCZKAX",
				"AITFQORCEHPVJMXGKSLNZWUY",
				"OTERVXFZUMHNIYSCQAWGPKJL",
				"VMSERIJYLZNWCPQTOKFUHAXG",
				"VNHOZWKQCEFYPSGLAMXJIUTR",
				"ANPHQIJMXCWOSKTYGULFVERZ",
				"RFYUXJEWCKQOMGATHZVILNSP",
				"SCPYUMQJTVEXKRNLIOWGHAFZ",
				"VIKTSJCEYQGLOMPZWAHFXURN",
				"SVJICLXKHQZTFWNPYRGMEUAO",
				"JRCTHYKIGSXPOZLUQAVNEWFM",
				"NGMSWJITREHFZVQCUKXYAPOL",
				"WUXJOQKGNSYLHEZAFIPMRCVT",
				"PKYQIOLXFCRGHZNAMJVUTWES",
				"FERSGNMJVZXWAYLIKCPUQHTO",
				"HPLRIUQMTSGYJVAXWNOCZEKF",
				"JUVWPTEGCOFYSKXNRMHQALIZ",
				"MWPIAZCNSLEYRTHFKQXUOVGJ",
				"EZXLUNFVCMORSIWKTYHJAQPG",
				"HRQNLTKJFIEGMCSXAZPYOVUW",
				"LOHXVYGWRIJMCPSQENUAKTZF",
				"XKUTWPRGHOAQFLVYMJSNEIZC",
				"WTCRQMVKPHOSLGAXZUEFYNJI",
			},
			"VWFHSJARNPEMOXLTUKICZGYQ")]
		public void RankTeams(string[] input, string expected)
		{
			var exercises = new RankTeamsByVotes();
			string actual = exercises.RankTeams(input);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(RemoveCommentsData))]
		public void RemoveComments(string[] input, string[] expected)
		{
			var exercises = new RemoveCodeComments();
			string[] actual = exercises.RemoveComments(input).ToArray();
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> RemoveCommentsData()
		{
			yield return
			[
				new[]
				{
					"/*Test program */",
					"int main()",
					"{ ",
					"  // variable declaration ",
					"int a, b, c;",
					"/* This is a test",
					"   multiline  ",
					"   comment for ",
					"   testing */",
					"a = b + c;",
					"}",
				},
				new[] { "int main()", "{ ", "  ", "int a, b, c;", "a = b + c;", "}" },
			];
			yield return
			[
				new[] { "a/*comment", "line", "more_comment*/b" }, new[] { "ab" },
			];
		}

		[Theory]
		[InlineData(
			new[] { 1, 2, 3, 0, 0, 0 },
			3,
			new[] { 2, 5, 6 },
			3,
			new[] { 1, 2, 2, 3, 5, 6 })]
		[InlineData(
			new[] { 1 },
			1,
			new int[] { },
			0,
			new[] { 1 })]
		[InlineData(
			new[] { 0 },
			0,
			new[] { 1 },
			1,
			new[] { 1 })]
		[InlineData(
			new[] { 0, 0, 0, 0, 0 },
			0,
			new[] { 1, 2, 3, 4, 5 },
			5,
			new[] { 1, 2, 3, 4, 5 })]
		public void MergeSortedArray(int[] nums1, int m, int[] nums2, int n, int[] expected)
		{
			var exercises = new MergeSortedArray();

			// exercises.Merge(
			exercises.MergeOptimized(
				nums1,
				m,
				nums2,
				n);
			Assert.Equal(expected, nums1);
		}

		public static IEnumerable<object[]> MeetingRoomIIMemberData()
		{
			yield return [new int[][] { [0, 30], [5, 10], [15, 20] }, 2];
			yield return [new int[][] { [7, 10], [2, 4] }, 1];
		}

		[Theory]
		[MemberData(nameof(MeetingRoomIIMemberData))]
		public void MeetingRoomsII(int[][] input, int expected)
		{
			var exercises = new MeetingRoomsII();
			var actual = exercises.MinMeetingRooms(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GroupAnagramsMemberData()
		{
			yield return
			[
				new[] { "eat", "tea", "tan", "ate", "nat", "bat" },
				new string[][]
				{
					["bat"],
					[
						"nat",
						"tan",
					],
					[
						"ate",
						"eat",
						"tea",
					],
				},
			];

			yield return
			[
				new[] { "" },
				new string[][] { [""], },
			];

			yield return
			[
				new[] { "a" },
				new string[][] { ["a"], },
			];
		}

		private void AssertEqualIgnoringOrder(
			IList<IList<string>> expected,
			IList<IList<string>> actual)
		{
			// Order the outer arrays by the sorted contents of the inner arrays
			var sortedExpected = expected
				.Select(inner => inner.OrderBy(x => x).ToArray())
				.OrderBy(inner => string.Join(",", inner))
				.ToArray();

			var sortedActual = actual
				.Select(inner => inner.OrderBy(x => x).ToArray())
				.OrderBy(inner => string.Join(",", inner))
				.ToArray();

			Assert.Equal(sortedExpected, sortedActual);
		}

		private void AssertEqualIgnoringOrder<T>(IEnumerable<T> actual, IEnumerable<T> expected)
		{
			var sortedActual = actual.Order();
			var sortedExpected = expected.Order();

			Assert.Equal(sortedExpected, sortedActual);
		}

		[Theory]
		[MemberData(nameof(GroupAnagramsMemberData))]
		public void GroupAnagrams(string[] input, IList<IList<string>> expected)
		{
			var exercises = new GroupAnagramStrings();
			IList<IList<string>> actual = exercises.GroupAnagrams(input);
			AssertEqualIgnoringOrder(expected, actual);
		}

		public static IEnumerable<object[]> LatestTimeCatchTheBusMemberData()
		{
			yield return
			[
				new[] { 10, 20 },
				new[] { 2, 17, 18, 19 },
				2,
				16,
			];

			yield return
			[
				new[] { 20, 30, 10 },
				new[] { 19, 13, 26, 4, 25, 11, 21 },
				2,
				20,
			];

			yield return
			[
				new[] { 3 },
				new[] { 2, 4 },
				2,
				3,
			];

			yield return
			[
				new[] { 5 },
				new[] { 7, 8 },
				1,
				5,
			];

			yield return
			[
				new[] { 6, 8, 18, 17 },
				new[] { 6, 8, 17 },
				1,
				18,
			];
		}

		[Theory]
		[MemberData(nameof(LatestTimeCatchTheBusMemberData))]
		public void LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity, int expected)
		{
			var exercises = new TheLatestTimeToCatchABus();
			int actual = exercises.LatestTimeCatchTheBus(buses, passengers, capacity);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(10, false)]
		[InlineData(1521, false)]
		public void ReorderedPowerOf2(int n, bool expected)
		{
			var exercises = new ReorderedPowerOfTwo();
			bool actual = exercises.ReorderedPowerOf2(n);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
		[InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
		[InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
		public void TwoSum(int[] nums, int target, int[] expected)
		{
			var exercises = new TwoSumToTarget();
			var actual = exercises.TwoSum(nums, target);
			AssertEqualIgnoringOrder(expected, actual);
		}
	}
}
