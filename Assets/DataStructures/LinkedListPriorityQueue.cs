using System;
using System.Collections.Generic;

public class LinkedListPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
{
	#region Private Variables

	LinkedList<T> linkedList;
	Dictionary<T, LinkedListNode<T>> locators;

	#endregion // Private Variables

	#region Constructor

	public LinkedListPriorityQueue()
	{
		linkedList = new LinkedList<T>();
		locators = new Dictionary<T, LinkedListNode<T>>();
	}

	#endregion // Constructor

	#region Public Functions

	public override void Add(T item)
	{
		LinkedListNode<T> node = new LinkedListNode<T>(item);
		// Empty list or item belongs past the last element
		if (linkedList.First == null || item.CompareTo(linkedList.Last.Value) > 0)
		{
			linkedList.AddLast(node);
		}

		for (LinkedListNode<T> iter = linkedList.First; iter != null; iter = iter.Next)
		{
			if (item.CompareTo(iter.Value) <= 0)
			{
				linkedList.AddBefore(iter, node);
			}
		}

		locators.Add(item, node);
	}

	public override void Clear()
	{
		linkedList.Clear();
		locators.Clear();
	}

	public override bool Contains(T item)
	{
		return locators.ContainsKey(item);
	}

	public override void CopyTo(T[] array, int arrayIndex)
	{
		linkedList.CopyTo(array, arrayIndex);
	}

	public override IEnumerator<T> GetEnumerator()
	{
		return linkedList.GetEnumerator();
	}

	public override T Peek()
	{
		return linkedList.First.Value;
	}

	public override T Pop()
	{
		T result = linkedList.First.Value;
		linkedList.RemoveFirst();
		locators.Remove(result);
		return result;
	}

	public override bool Remove(T item)
	{
		LinkedListNode<T> node;
		if (locators.TryGetValue(item, out node))
		{
			linkedList.Remove(node);
			locators.Remove(item);
			return true;
		}

		return false;
	}

	public override void UpdatePosition(T currentItem, T newItem)
	{
		if (Remove(currentItem)) Add(newItem);
	}

	#endregion // Public Functions
}
