using UnityEngine;

public class CompoundResult : ConversationResult
{
	[SerializeField] private ConversationResult[] subResults;

	public override void Apply()
	{
		for (int i = 0; i < subResults.Length; ++i)
		{
			subResults[i].Apply();
		}
	}
}
