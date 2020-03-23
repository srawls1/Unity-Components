using UnityEngine;

public abstract class Requirement : ScriptableObject
{
	public abstract bool isMet { get; }
}
