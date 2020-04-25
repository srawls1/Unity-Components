using UnityEngine;
using XNode;

[CreateAssetMenu]
public class Conversation : NodeGraph
{
	[SerializeField] private string[] m_characters;
	public string[] characters => m_characters;

	[SerializeField] private ConversationNode m_first;
	public ConversationNode first => m_first;
}
