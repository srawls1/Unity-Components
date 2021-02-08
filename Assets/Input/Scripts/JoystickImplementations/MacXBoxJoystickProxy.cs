using System.Collections.Generic;
using UnityEngine;

public class MacXBoxJoystickProxy : PlayerInputProxy
{
	private const string RIGHT_TRIGGER = "MXB_RightTrigger";
	private const string LEFT_TRIGGER = "MXB_LeftTrigger";
	private const string LEFT_STICK_HORIZONTAL = "MXB_LeftStickHorizontal";
	private const string LEFT_STICK_VERTICAL = "MXB_LeftStickVertical";
	private const string RIGHT_STICK_HORIZONTAL = "MXB_RightStickHorizontal";
	private const string RIGHT_STICK_VERTICAL = "MXB_RightStickVertical";

	private Dictionary<JoystickButton, ButtonMapping> buttonMappings;
	private Dictionary<JoystickAxis, AxisMapping> axisMappings;

	public MacXBoxJoystickProxy(int controllerNumber = 0)
	{
		string numSuffix = controllerNumber == 0 ? string.Empty : controllerNumber.ToString();
		buttonMappings = new Dictionary<JoystickButton, ButtonMapping>();
		buttonMappings.Add(JoystickButton.SelectFaceButton, new SimpleButtonMapping(KeyCode.JoystickButton16 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.CancelFaceButton, new SimpleButtonMapping(KeyCode.JoystickButton17 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.LeftFaceButton, new SimpleButtonMapping(KeyCode.JoystickButton18 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.TopFaceButton, new SimpleButtonMapping(KeyCode.JoystickButton19 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.DPadDown, new SimpleButtonMapping(KeyCode.JoystickButton6 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.DPadUp, new SimpleButtonMapping(KeyCode.JoystickButton5 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.DPadRight, new SimpleButtonMapping(KeyCode.JoystickButton8 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.DPadLeft, new SimpleButtonMapping(KeyCode.JoystickButton7 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.RightShoulder1, new SimpleButtonMapping(KeyCode.JoystickButton14 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.RightShoulder2, new JoystickAxisButtonMapping(1f, 0f, RIGHT_TRIGGER + numSuffix));
		buttonMappings.Add(JoystickButton.LeftShoulder1, new SimpleButtonMapping(KeyCode.JoystickButton13 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.LeftShoulder2, new JoystickAxisButtonMapping(1f, 0f, LEFT_TRIGGER + numSuffix));
		buttonMappings.Add(JoystickButton.LeftStickPress, new SimpleButtonMapping(KeyCode.JoystickButton11 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.RightStickPress, new SimpleButtonMapping(KeyCode.JoystickButton12 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.Start, new SimpleButtonMapping(KeyCode.JoystickButton9 + controllerNumber * 20));
		buttonMappings.Add(JoystickButton.Select, new SimpleButtonMapping(KeyCode.JoystickButton10 + controllerNumber * 20));

		axisMappings = new Dictionary<JoystickAxis, AxisMapping>();
		axisMappings.Add(JoystickAxis.LeftStickHorizontal, new SimpleAxisMapping(LEFT_STICK_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.LeftStickVertical, new SimpleAxisMapping(LEFT_STICK_VERTICAL + numSuffix));
		axisMappings.Add(JoystickAxis.RightStickHorizontal, new SimpleAxisMapping(RIGHT_STICK_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.RightStickVertical, new SimpleAxisMapping(RIGHT_STICK_VERTICAL + numSuffix));
		axisMappings.Add(JoystickAxis.DPadHorizontal, new ButtonAxisMapping(KeyCode.JoystickButton8 + controllerNumber * 20, KeyCode.JoystickButton7 + controllerNumber * 20));
		axisMappings.Add(JoystickAxis.DPadVertical, new ButtonAxisMapping(KeyCode.JoystickButton5 + controllerNumber * 20, KeyCode.JoystickButton6 + controllerNumber * 20));
		axisMappings.Add(JoystickAxis.RightTrigger, new SimpleAxisMapping(RIGHT_TRIGGER + numSuffix));
		axisMappings.Add(JoystickAxis.LeftTrigger, new SimpleAxisMapping(LEFT_TRIGGER + numSuffix));
	}



	public override ControllerType controllerType => ControllerType.XBox;

	protected override AxisMapping convertAxisInfoToMapping(AxisInfo info)
	{
		return axisMappings[info.joystickAxis];
	}

	protected override ButtonMapping convertButtonInfoToMapping(ButtonInfo info)
	{
		return buttonMappings[info.button];
	}
}
