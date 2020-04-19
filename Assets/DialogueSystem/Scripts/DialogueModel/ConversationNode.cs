using System;
using System.Collections;
using UnityEngine;
using XNode;

[Serializable]
public class SerializableStringDictionary : SerializableDictionary<string, string> { }

public abstract class ConversationNode : Node
{
	[SerializeField] private SerializableStringDictionary m_attributes;

	public abstract bool isRequirementMet { get; }

	public bool HasAttribute(string key)
	{
		return m_attributes.ContainsKey(key);
	}

	public string GetAttribute(string key)
	{
		return m_attributes[key];
	}

	public override object GetValue(NodePort port)
	{
		return 0;
	}

	public abstract IEnumerator AcceptVisitor(ConversationVisitor visitor);
	public abstract ConversationNode GetNext();
}
