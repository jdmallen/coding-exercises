using JDMallen.CodingExercises.LeetCode.Shared;

namespace JDMallen.CodingExercises.LeetCode;

public class Add2Numbers
{
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		ListNode firstNumber = l1;
		ListNode secondNumber = l2;
		ListNode result = null;
		ListNode pointer = null;
		var place = 1;
		var remainder = 0;

		while (firstNumber != null && secondNumber != null)
		{
			int placeSum = firstNumber.val + secondNumber.val + remainder;
			int digit = placeSum < 10 ? placeSum : placeSum - 10;

			if (result == null)
			{
				result = new ListNode(digit);
				pointer = result;
			}
			else
			{
				pointer.next = new ListNode(digit);
				pointer = pointer.next;
			}

			remainder = placeSum >= 10 ? placeSum / 10 : 0;
			firstNumber = firstNumber.next;
			secondNumber = secondNumber.next;
		}

		if (firstNumber == null && secondNumber != null && pointer != null)
		{
			while (secondNumber != null)
			{
				int placeSum = secondNumber.val + remainder;
				int digit = placeSum < 10 ? placeSum : placeSum - 10;

				pointer.next = new ListNode(digit);
				pointer = pointer.next;

				remainder = placeSum >= 10 ? placeSum / 10 : 0;
				secondNumber = secondNumber.next;
			}
		}

		if (firstNumber != null && secondNumber == null && pointer != null)
		{
			while (firstNumber != null)
			{
				int placeSum = firstNumber.val + remainder;
				int digit = placeSum < 10 ? placeSum : placeSum - 10;

				pointer.next = new ListNode(digit);
				pointer = pointer.next;

				remainder = placeSum >= 10 ? placeSum / 10 : 0;
				firstNumber = firstNumber.next;
			}
		}

		if (firstNumber == null && secondNumber == null && pointer != null)
		{
			if (remainder == 0)
			{
				return result;
			}

			pointer.next = new ListNode(remainder);

			return result;
		}

		return result;
	}
}
