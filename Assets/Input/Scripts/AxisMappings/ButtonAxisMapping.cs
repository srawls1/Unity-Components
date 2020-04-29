using UnityEngine;

public class ButtonAxisMapping : AxisMapping
{
	private string positiveButtonName;
	private string negativeButtonName;

	public ButtonAxisMapping(string positiveButtonName, string negativeButtonName = "")
	{
		this.positiveButtonName = positiveButtonName;
		this.negativeButtonName = negativeButtonName;
	}

	public override float value
	{
		get
		{
			if (Input.GetKey(positiveButtonName))
			{
				return 1f;
			}
			if (!string.IsNullOrEmpty(negativeButtonName) && Input.GetKey(negativeButtonName))
			{
				return -1f;
			}

			return 0f;
		}
	}
}
