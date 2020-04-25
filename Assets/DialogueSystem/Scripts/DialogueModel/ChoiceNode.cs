using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XNode;

public class ChoiceNode : ConversationNode
{
	public override bool isRequirementMet => true;

	public ReadOnlyCollection<LineNode> GetPossibleResponses()
	{
		List<LineNode> elligibleResponses = new List<LineNode>();
		List<NodePort> connections = GetOutputPort("next").GetConnections();
		for (int i = 0; i < connections.Count; ++i)
		{
			LineNode response = connections[i].node as LineNode;
			if (response.isRequirementMet)
			{
				elligibleResponses.Add(response);
			}
		}

		return elligibleResponses.AsReadOnly();
	}

	private LineNode choice;
	public void SetResponse(LineNode choice)
	{
		this.choice = choice;
	}

	public override IEnumerator AcceptVisitor(ConversationVisitor visitor)
	{
		return visitor.VisitChoice(this);
	}

	public override ConversationNode GetNext()
	{
		return choice;
	}
}
