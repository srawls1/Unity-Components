using UnityEngine;

public abstract class ButtonMapping
{
	// Most button mappings are stateless and don't need to update.
	// However, some do need to have Update called once per frame.
	public virtual void Update() { } 
	public abstract bool	isButtonPressed		{ get; }
	public abstract bool	isButtonHeld		{ get; }
	public abstract bool	isButtonReleased	{ get; }
}
