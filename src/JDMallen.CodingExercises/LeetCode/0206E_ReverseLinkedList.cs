using JDMallen.CodingExercises.LeetCode.Shared;

namespace JDMallen.CodingExercises.LeetCode;

public class ReverseLinkedList
{
	public ListNode ReverseList(ListNode head)
	{
		return ReverseList(head, null);

		// lastNode is now last node
	}

	private ListNode ReverseList(ListNode original, ListNode newList)
	{
		if (original == null)
		{
			return null;
		}

		if (original.next == null)
		{
			return original;
		}

		ListNode head = original;
		ListNode previousNode = original;
		while (original.next != null)
		{
			previousNode = original;
			original = original.next;
		}

		// head is still at head of original list
		// previousNode is at 2nd-to-last node
		// original now at last node

		if (head == previousNode && newList == null && head.next != null)
		{
			// there are only 2 nodes
			int secondVal = head.next.val;
			head.next = null;

			return new ListNode(secondVal, head);
		}

		previousNode.next = null;

		// if first round, initialize it
		if (newList == null)
		{
			newList = new ListNode(original.val, previousNode);

			return ReverseList(head, newList);
		}

		// otherwise, fast forward to end of new list and append
		ListNode pointer = newList;
		while (pointer.next != null)
		{
			pointer = pointer.next;
		}

		pointer.next = new ListNode(previousNode.val, null);

		if (head == previousNode)
		{
			//rewind new list
			return newList;
		}

		return ReverseList(head, newList);
	}
}
