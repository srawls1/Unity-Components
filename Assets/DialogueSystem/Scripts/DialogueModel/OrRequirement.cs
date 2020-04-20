using UnityEngine;

public class OrRequirement : Requirement
{
	[SerializeField] private Requirement[] subRequirements;

	public override bool isMet
	{
		get
		{
			for (int i = 0; i < subRequirements.Length; ++i)
			{
				if (subRequirements[i].isMet)
				{
					return true;
				}
			}

			return false;
		}
	}
}
