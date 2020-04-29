using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputProxy : MonoBehaviour
{
	public enum ControllerType
	{
		KeyboardAndMouse,
		XBox,
		PS3,
		PS4,
		SwitchPro,
		PairedJoyCon,
		SingleJoyCon
	}

	[SerializeField] private float axisThreshold;

	protected ButtonMapping[] possibleButtons;
	protected AxisMapping[] possibleAxes;
	private Dictionary<string, ButtonMapping> mappedActions;
	private Dictionary<string, AxisMapping> mappedAxisActions;

	public abstract ControllerType controllerType
	{
		get;
	}

	public bool isActive => pressedButton != null || nonZeroAxis != null;
	public ButtonMapping pressedButton { get; private set; }
	public AxisMapping nonZeroAxis { get; private set; }

	protected void Awake()
	{
		possibleButtons = getButtonMappings();
		possibleAxes = getAxisMappings();
		mappedActions = new Dictionary<string, ButtonMapping>();
		mappedAxisActions = new Dictionary<string, AxisMapping>();
	}

	protected void Update()
	{
		pressedButton = null;
		nonZeroAxis = null;

		for (int i = 0; i < possibleButtons.Length; ++i)
		{
			possibleButtons[i].Update();
			if (possibleButtons[i].isButtonPressed)
			{
				pressedButton = possibleButtons[i];
			}
		}

		for (int i = 0; i < possibleAxes.Length; ++i)
		{
			if (Mathf.Abs(possibleAxes[i].value) > axisThreshold)
			{
				nonZeroAxis = possibleAxes[i];
			}
		}
	}

	protected abstract ButtonMapping[] getButtonMappings();
	protected abstract AxisMapping[] getAxisMappings();

	public void MapAction(string actionName, ButtonMapping button)
	{
		mappedActions[actionName] = button;
	}

	public void MapAxisAction(string axisActionName, AxisMapping axis)
	{
		mappedAxisActions[axisActionName] = axis;
	}

	public float GetAxis(string axisName)
	{
		return mappedAxisActions[axisName].value;
	}

	public bool GetButton(string buttonName)
	{
		return mappedActions[buttonName].isButtonHeld;
	}

	public bool GetButtonDown(string buttonName)
	{
		return mappedActions[buttonName].isButtonPressed;
	}

	public bool GetButtonUp(string buttonName)
	{
		return mappedActions[buttonName].isButtonReleased;
	}
}
