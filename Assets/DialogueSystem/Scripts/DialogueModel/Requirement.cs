using UnityEngine;

public abstract class Requirement : ScriptableObject
{
	public virtual bool isStateless { get { return false; } }
	public abstract bool isMet { get; }
}
