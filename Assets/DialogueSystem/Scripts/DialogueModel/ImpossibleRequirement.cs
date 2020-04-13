public class ImpossibleRequirement : Requirement
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
			return false;
		}
	}
}
