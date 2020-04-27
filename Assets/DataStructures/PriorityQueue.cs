using System;
using System.Collections;
using System.Collections.Generic;

public abstract class PriorityQueue<T> : ICollection<T> where T : IComparable<T>
{
	#region Public Properties

	public int Count
	{
		get;
		protected set;
	}

	public bool IsReadOnly
	{
		get { return false; }
	}

	#endregion // Public Properties

	#region Public Functions

	public abstract T Peek();
	public abstract T Pop();
	public abstract void UpdatePosition(T currentItem, T newItem);
	public abstract void Add(T item);
	public abstract void Clear();
	public abstract bool Contains(T item);
	public abstract void CopyTo(T[] array, int arrayIndex);
	public abstract IEnumerator<T> GetEnumerator();
	public abstract bool Remove(T item);

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	#endregion // Public Functions
}