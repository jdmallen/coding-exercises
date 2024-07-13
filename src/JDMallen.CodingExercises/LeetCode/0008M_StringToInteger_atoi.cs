namespace JDMallen.CodingExercises.LeetCode;

public class StringToIntegerAtoi
{
	public int MyAtoi(string s)
	{
		sbyte sign = 1;
		long temp = 0;
		foreach (char c in s)
		{
			if (c == '-')
			{
				sign *= -1;

				continue;
			}

			if ((c < 48 || c > 57) && c != ' ' && c != '-' && c != '+' && temp == 0)
			{
				return 0;
			}

			if (c == '.')
			{
				break;
			}

			if (c == ' ' || c == '+' || c < 48 || c > 57)
			{
				continue;
			}

			temp = temp * 10 + (c - '0');
		}

		temp *= sign;

		return temp > int.MaxValue ? int.MaxValue :
			temp < int.MinValue ? int.MinValue : (int)temp;
	}
}
