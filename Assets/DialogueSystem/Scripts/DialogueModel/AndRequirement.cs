using UnityEngine;

public class AndRequirement : Requirement
{
	[SerializeField] private Requirement[] subRequirements;

	public override bool isMet
	{
		get
		{
			for (int i = 0; i < subRequirements.Length; ++i)
			{
				if (!subRequirements[i].isMet)
				{
					return false;
				}
			}

			return true;
		}
	}
}
