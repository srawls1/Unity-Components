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
		buttonMappings.Add(JoystickButton.SelectFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button16));
		buttonMappings.Add(JoystickButton.CancelFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button17));
		buttonMappings.Add(JoystickButton.LeftFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button18));
		buttonMappings.Add(JoystickButton.TopFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button19));
		buttonMappings.Add(JoystickButton.DPadDown, new SimpleButtonMapping(KeyCode.Joystick1Button6));
		buttonMappings.Add(JoystickButton.DPadUp, new SimpleButtonMapping(KeyCode.Joystick1Button5));
		buttonMappings.Add(JoystickButton.DPadRight, new SimpleButtonMapping(KeyCode.Joystick1Button8));
		buttonMappings.Add(JoystickButton.DPadLeft, new SimpleButtonMapping(KeyCode.Joystick1Button7));
		buttonMappings.Add(JoystickButton.RightShoulder1, new SimpleButtonMapping(KeyCode.Joystick1Button14));
		buttonMappings.Add(JoystickButton.RightShoulder2, new JoystickAxisButtonMapping(1f, 0f, RIGHT_TRIGGER + numSuffix));
		buttonMappings.Add(JoystickButton.LeftShoulder1, new SimpleButtonMapping(KeyCode.Joystick1Button13));
		buttonMappings.Add(JoystickButton.LeftShoulder2, new JoystickAxisButtonMapping(1f, 0f, LEFT_TRIGGER + numSuffix));
		buttonMappings.Add(JoystickButton.LeftStickPress, new SimpleButtonMapping(KeyCode.Joystick1Button11));
		buttonMappings.Add(JoystickButton.RightStickPress, new SimpleButtonMapping(KeyCode.Joystick1Button12));
		buttonMappings.Add(JoystickButton.Start, new SimpleButtonMapping(KeyCode.Joystick1Button9));
		buttonMappings.Add(JoystickButton.Select, new SimpleButtonMapping(KeyCode.Joystick1Button10));

		axisMappings = new Dictionary<JoystickAxis, AxisMapping>();
		axisMappings.Add(JoystickAxis.LeftStickHorizontal, new SimpleAxisMapping(LEFT_STICK_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.LeftStickVertical, new SimpleAxisMapping(LEFT_STICK_VERTICAL + numSuffix));
		axisMappings.Add(JoystickAxis.RightStickHorizontal, new SimpleAxisMapping(RIGHT_STICK_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.RightStickVertical, new SimpleAxisMapping(RIGHT_STICK_VERTICAL + numSuffix));
		axisMappings.Add(JoystickAxis.DPadHorizontal, new ButtonAxisMapping(KeyCode.Joystick1Button8, KeyCode.Joystick1Button7));
		axisMappings.Add(JoystickAxis.DPadVertical, new ButtonAxisMapping(KeyCode.Joystick1Button5, KeyCode.Joystick1Button6));
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
