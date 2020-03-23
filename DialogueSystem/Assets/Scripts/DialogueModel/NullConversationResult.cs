using System;
using UnityEngine;

[CreateAssetMenu]
public class NullConversationResult : ConversationResult
{
	public override void Apply()
	{
		Debug.Log("Null result");
	}
}
