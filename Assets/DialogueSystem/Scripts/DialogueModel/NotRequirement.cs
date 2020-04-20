using UnityEngine;

public class NotRequirement : Requirement
{
	[SerializeField] private Requirement subRequirement;

	public override bool isMet
	{
		get
		{
			return !subRequirement.isMet;
		}
	}
}
