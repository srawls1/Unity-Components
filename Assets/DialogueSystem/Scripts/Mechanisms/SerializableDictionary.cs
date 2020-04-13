using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableDictionary<K, V> : ISerializationCallbackReceiver, IReadOnlyDictionary<K, V>
{
	[SerializeField] private K[] keys;
	[SerializeField] private V[] values;

	private Dictionary<K, V> dictionary;

	public IEnumerable<K> Keys
	{
		get
		{
			return dictionary.Keys;
		}
	}

	public IEnumerable<V> Values
	{
		get
		{
			return dictionary.Values;
		}
	}

	public int Count
	{
		get
		{
			return dictionary.Count;
		}
	}

	public V this[K key]
	{
		get
		{
			return dictionary[key];
		}
	}

	public void OnAfterDeserialize()
	{
		Debug.Assert(keys.Length == values.Length);

		dictionary = new Dictionary<K, V>(keys.Length);
		for (int i = 0; i < keys.Length; ++i)
		{
			dictionary.Add(keys[i], values[i]);
		}

		keys = null;
		values = null;
	}

	public void OnBeforeSerialize()
	{
		if (dictionary == null)
		{
			keys = new K[0];
			values = new V[0];
			return;
		}

		keys = new K[dictionary.Count];
		values = new V[dictionary.Count];
		int i = 0;
		foreach (KeyValuePair<K, V> pair in dictionary)
		{
			int index = i++;
			keys[index] = pair.Key;
			values[index] = pair.Value;
		}

		dictionary.Clear();
		dictionary = null;
	}

	public bool ContainsKey(K key)
	{
		return dictionary.ContainsKey(key);
	}

	public bool TryGetValue(K key, out V value)
	{
		return dictionary.TryGetValue(key, out value);
	}

	public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
	{
		return dictionary.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return dictionary.GetEnumerator();
	}
}
