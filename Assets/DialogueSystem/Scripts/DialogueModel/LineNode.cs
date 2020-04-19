using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class LineNode : ConversationNode
{
	[SerializeField] private string m_text;
	[SerializeField] private string m_character;
	[SerializeField] private AudioClip m_audio;
	[SerializeField] private Animation m_animation;
	[SerializeField] private Requirement requirement;
	[SerializeField] private ConversationResult result;


	[Input]
	public int previous;
	[Output]
	public int next;

	public string text { get { return m_text; } }
	public string character { get { return m_character; } }
	public bool hasAudio { get { return m_audio != null; } }
	public AudioClip audio { get { return m_audio; } }
	public bool hasAnimation { get { return m_animation != null; } }
	public Animation animation { get { return m_animation; } }

	public override bool isRequirementMet => requirement.isMet;

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
		NodePort outPort = GetOutputPort("next");
		List<NodePort> nextOptions = outPort.GetConnections();
		for (int i = 0; i < nextOptions.Count; ++i)
		{
			ConversationNode nextNode = nextOptions[i].node as ConversationNode;
			if (nextNode.isRequirementMet)
			{
				return nextNode;
			}
		}

		return null;
	}
}
