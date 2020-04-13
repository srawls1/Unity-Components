using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct ConditionalConversationPath
{
	public Requirement condition;
	public ConversationNode next;
}

[CreateAssetMenu]
public class LineNode : ConversationNode
{
	[SerializeField] private DialogueLine m_line;
	[SerializeField] private ConditionalConversationPath[] nextOptions;
	[SerializeField] private ConversationResult result;

	public DialogueLine line { get { return m_line; } }

	public override IEnumerator AcceptVisitor(ConversationVisitor visitor)
	{
		IEnumerator visit = visitor.VisitLine(this);
		while (visit.MoveNext())
		{
			yield return visit.Current;
		}

		result.Apply();
	}

	public override ConversationNode GetNext()
	{
		foreach (ConditionalConversationPath option in nextOptions)
		{
			if (option.condition.isMet)
			{
				return option.next;
			}
		}
		return null;
	}
}
