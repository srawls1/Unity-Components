using UnityEngine;

public class ButtonAxisMapping : AxisMapping
{
	private KeyCode positiveButton;
	private KeyCode negativeButton;

	public ButtonAxisMapping(KeyCode positiveButton, KeyCode negativeButton = KeyCode.None)
	{
		this.positiveButton = positiveButton;
		this.negativeButton = negativeButton;
	}

	public override float value
	{
		get
		{
			if (Input.GetKey(positiveButton))
			{
				return 1f;
			}
			if (negativeButton != KeyCode.None && Input.GetKey(negativeButton))
			{
				return -1f;
			}

			return 0f;
		}
	}
}
