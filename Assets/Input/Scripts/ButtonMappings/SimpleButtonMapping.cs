using UnityEngine;

public class SimpleButtonMapping : ButtonMapping
{
	private KeyCode key;

	public SimpleButtonMapping(KeyCode key)
	{
		this.key = key;
	}

	public override bool isButtonPressed	=> Input.GetKeyDown(key);
	public override bool isButtonHeld		=> Input.GetKey(key);
	public override bool isButtonReleased	=> Input.GetKeyUp(key);
}
