using UnityEngine;

public class NullRequirement : Requirement
{
	public override bool isStateless
	{
		get
		{
			return true;
		}
	}

	public override bool isMet
	{
		get
		{
			return true;
		}
	}
}
