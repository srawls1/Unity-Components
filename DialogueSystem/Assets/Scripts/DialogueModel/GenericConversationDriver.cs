using System.Collections;

public class GenericConversationDriver
{
	private ConversationNode firstNode;
	private ConversationVisitor visitor;

	public GenericConversationDriver(ConversationNode firstNode, ConversationVisitor visitor)
	{
		this.firstNode = firstNode;
		this.visitor = visitor;
	}

	public IEnumerator ConversationRoutine()
	{
		for (ConversationNode node = firstNode; node != null; node = node.GetNext())
		{
			IEnumerator nodeRoutine = node.AcceptVisitor(visitor);
			while (nodeRoutine.MoveNext())
			{
				yield return nodeRoutine.Current;
			}
		}

	}
}
