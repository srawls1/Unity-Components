using System.Collections;
using UnityEngine;

public abstract class ConversationNode : ScriptableObject
{
	public abstract IEnumerator AcceptVisitor(ConversationVisitor visitor);
	public abstract ConversationNode GetNext();
}
