using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputProxy : MonoBehaviour
{
	[SerializeField] private PlayerInputManager inputManager;
	[SerializeField] private float axisThreshold;

	protected List<ButtonMapping> possibleButtons;
	protected List<AxisMapping> possibleAxes;
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

		for (int i = 0; i < possibleButtons.Count; ++i)
		{
			possibleButtons[i].Update();
			if (possibleButtons[i].isButtonPressed)
			{
				pressedButton = possibleButtons[i];
			}
		}

		for (int i = 0; i < possibleAxes.Count; ++i)
		{
			if (Mathf.Abs(possibleAxes[i].value) > axisThreshold)
			{
				nonZeroAxis = possibleAxes[i];
			}
		}
	}

	protected List<ButtonMapping> getButtonMappings()
	{
		List<ButtonMapping> buttons = new List<ButtonMapping>();

		for (int i = 0; i < inputManager.buttonCount; ++i)
		{
			if (inputManager.ButtonAt(i).controllerType != controllerType)
			{
				continue;
			}

			buttons.Add(convertButtonInfoToMapping(inputManager.ButtonAt(i)));
		}

		return buttons;
	}

	protected List<AxisMapping> getAxisMappings()
	{
		List<AxisMapping> axes = new List<AxisMapping>();

		for (int i = 0; i < inputManager.axisCount; ++i)
		{
			if (inputManager.AxisAt(i).controllerType != controllerType)
			{
				continue;
			}

			axes.Add(convertAxisInfoToMapping(inputManager.AxisAt(i)));
		}

		return axes;
	}

	protected abstract ButtonMapping convertButtonInfoToMapping(ButtonInfo info);
	protected abstract AxisMapping convertAxisInfoToMapping(AxisInfo info);

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
