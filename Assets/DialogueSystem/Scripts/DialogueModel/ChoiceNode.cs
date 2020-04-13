using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class ResponseToNodeDictionary
	: SerializableDictionary<ResponseOption, ConversationNode> { }

[CreateAssetMenu]
public class ChoiceNode : ConversationNode
{
	[SerializeField] private ResponseToNodeDictionary responseOptions;

	private List<ResponseOption> possibleResponses = new List<ResponseOption>();
	public ReadOnlyCollection<ResponseOption> GetPossibleResponses()
	{
		possibleResponses.Clear();
		foreach (KeyValuePair<ResponseOption, ConversationNode> responseOption in responseOptions)
		{
			if (responseOption.Key.requirement.isMet)
			{
				possibleResponses.Add(responseOption.Key);
			}
		}

		return possibleResponses.AsReadOnly();
	}

	private ResponseOption choice;
	public void SetResponse(ResponseOption choice)
	{
		this.choice = choice;
	}

	public override IEnumerator AcceptVisitor(ConversationVisitor visitor)
	{
		return visitor.VisitChoice(this);
	}

	public override ConversationNode GetNext()
	{
		return responseOptions[choice];
	}
}
