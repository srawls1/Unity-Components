using System.Collections;
using XNode;

public abstract class ConversationNode : Node
{
	public abstract bool isRequirementMet { get; }

	public override object GetValue(NodePort port)
	{
		return 0;
	}

	public abstract IEnumerator AcceptVisitor(ConversationVisitor visitor);
	public abstract ConversationNode GetNext();
}
