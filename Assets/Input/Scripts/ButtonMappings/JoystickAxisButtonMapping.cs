using UnityEngine;

public class JoystickAxisButtonMapping : ButtonMapping
{
	private float pressedAxisValue;
	private float releasedAxisValue;
	private string axisName;

	private bool currentValue;
	private bool previousValue;

	public JoystickAxisButtonMapping(float pressedAxisValue, float releasedAxisValue, string axisName)
	{
		this.pressedAxisValue = pressedAxisValue;
		this.releasedAxisValue = releasedAxisValue;
		this.axisName = axisName;
	}

	public override void Update()
	{
		previousValue = currentValue;
		float axisValue = Input.GetAxisRaw(axisName);
		currentValue = Mathf.Abs(axisValue - pressedAxisValue) > Mathf.Abs(axisValue - releasedAxisValue);
	}

	public override bool isButtonHeld
	{
		get
		{
			return currentValue;
		}
	}

	public override bool isButtonPressed
	{
		get
		{
			return currentValue && !previousValue;
		}
	}

	public override bool isButtonReleased
	{
		get
		{
			return previousValue && !currentValue;
		}
	}
}
