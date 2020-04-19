using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class Conversation : NodeGraph
{
	[SerializeField] private ConversationNode m_first;
	public ConversationNode first => m_first;
}
