using UnityEngine;

[CreateAssetMenu]
public class NullRequirement : Requirement
{
	public override bool isMet
	{
		get
		{
			return true;
		}
	}
}
