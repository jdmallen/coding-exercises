using System;
using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class WebCrawlerMultithreaded
{
	public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
	{
		var set = new HashSet<string> { startUrl };
		string hostname = new Uri(startUrl).Host;
		List<string> urls = htmlParser.GetUrls(startUrl);

		foreach (string url in urls.Where(
			         u => new Uri(u).Host.Equals(hostname, StringComparison.OrdinalIgnoreCase)))
		{
			set.UnionWith(Crawl(url, htmlParser));
		}

		return set.ToList();
	}

	public class HtmlParser
	{
		public static IList<string> Urls = new List<string>
		{
			"http://news.yahoo.com",
			"http://news.yahoo.com/news",
			"http://news.yahoo.com/news/topics/",
			"http://news.google.com",
			"http://news.yahoo.com/us"
		};

		public List<string> GetUrls(string url)
		{
			if (url == Urls[2])
			{
				return new List<string>
				{
					Urls[0],
					Urls[1]
				};
			}

			if (url == Urls[3])
			{
				return new List<string>
				{
					Urls[2],
					Urls[1]
				};
			}

			if (url == Urls[0])
			{
				return new List<string>() { Urls[4] };
			}

			return new List<string>();
		}
	}
}
