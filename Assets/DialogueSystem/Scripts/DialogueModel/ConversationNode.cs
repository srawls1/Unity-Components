using System.Collections;
using UnityEngine;
using XNode;

public abstract class ConversationNode : Node
{
	[Input]	[SerializeField] private int previous;
	[Output][SerializeField] private int next;

	public abstract bool isRequirementMet { get; }

	public override object GetValue(NodePort port)
	{
		return 0;
	}

	public abstract IEnumerator AcceptVisitor(ConversationVisitor visitor);
	public abstract ConversationNode GetNext();
}
