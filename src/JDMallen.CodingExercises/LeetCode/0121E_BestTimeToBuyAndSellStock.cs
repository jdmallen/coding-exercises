namespace JDMallen.CodingExercises.LeetCode;

public class BestTimeToBuyAndSellStock
{
	public int MaxProfit(int[] prices)
	{
		if (prices.Length <= 1)
		{
			return 0;
		}

		int minValue = int.MaxValue;
		int maxProfit = 0;

		for (int i = 0; i < prices.Length; i++)
		{
			int price = prices[i];

			if (price < minValue)
			{
				minValue = price;
			}
			else if (price - minValue > maxProfit)
			{
				maxProfit = price - minValue;
			}
		}

		return maxProfit;
	}
}
