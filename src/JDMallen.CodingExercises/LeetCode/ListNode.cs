using System;

namespace JDMallen.CodingExercises.LeetCode;

public class ListNode : IEquatable<ListNode>
{
	public int val;
	public ListNode next;

	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
	public bool Equals(ListNode other)
	{
		if (ReferenceEquals(null, other))
		{
			return false;
		}

		if (ReferenceEquals(this, other))
		{
			return true;
		}

		return val == other.val
			&& Equals(next, other.next);
	}

	/// <summary>Determines whether the specified object is equal to the current object.</summary>
	/// <param name="obj">The object to compare with the current object.</param>
	/// <returns>
	/// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}

		if (ReferenceEquals(this, obj))
		{
			return true;
		}

		if (obj.GetType() != GetType())
		{
			return false;
		}

		return Equals((ListNode)obj);
	}

	/// <summary>Serves as the default hash function.</summary>
	/// <returns>A hash code for the current object.</returns>
	public override int GetHashCode() => HashCode.Combine(val, next);
}
