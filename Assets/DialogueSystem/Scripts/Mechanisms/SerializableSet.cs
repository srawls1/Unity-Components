using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableSet<T> : ISerializationCallbackReceiver, IReadOnlyCollection<T>
{
	[SerializeField] private T[] elems;

	private HashSet<T> set;

	public int Count
	{
		get
		{
			return set.Count;
		}
	}

	public void OnAfterDeserialize()
	{
		set = new HashSet<T>(elems);
		elems = null;
	}

	public void OnBeforeSerialize()
	{
		elems = new T[set.Count];
		int i = 0;
		foreach (T t in set)
		{
			elems[i++] = t;
		}

		set.Clear();
		set = null;
	}

	public bool Contains(T t)
	{
		return set.Contains(t);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return set.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return set.GetEnumerator();
	}
}
