using System.Collections.Generic;
using UnityEngine;

public class WindowsXBoxJoystickProxy : PlayerInputProxy
{
	private const string DPAD_VERTICAL = "WXB_DPadVertical";
	private const string DPAD_HORIZONTAL = "WXB_DPadHorizontal";
	private const string RIGHT_TRIGGER = "WXB_RightTrigger";
	private const string LEFT_TRIGGER = "WXB_LeftTrigger";
	private const string LEFT_STICK_HORIZONTAL = "WXB_LeftStickHorizontal";
	private const string LEFT_STICK_VERTICAL = "WXB_LeftStickVertical";
	private const string RIGHT_STICK_HORIZONTAL = "WXB_RightStickHorizontal";
	private const string RIGHT_STICK_VERTICAL = "WXB_RightStickVertical";

	private Dictionary<JoystickButton, ButtonMapping> buttonMappings;
	private Dictionary<JoystickAxis, AxisMapping> axisMappings;

	public WindowsXBoxJoystickProxy(int controllerNumber = 0)
	{
		string numSuffix = controllerNumber == 0 ? string.Empty : controllerNumber.ToString();
		buttonMappings = new Dictionary<JoystickButton, ButtonMapping>();
		buttonMappings.Add(JoystickButton.SelectFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button0));
		buttonMappings.Add(JoystickButton.CancelFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button1));
		buttonMappings.Add(JoystickButton.LeftFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button2));
		buttonMappings.Add(JoystickButton.TopFaceButton, new SimpleButtonMapping(KeyCode.Joystick1Button3));
		buttonMappings.Add(JoystickButton.DPadDown, new JoystickAxisButtonMapping(-1f, 0f, DPAD_VERTICAL + numSuffix));
		buttonMappings.Add(JoystickButton.DPadUp, new JoystickAxisButtonMapping(1f, 0f, DPAD_VERTICAL + numSuffix));
		buttonMappings.Add(JoystickButton.DPadRight, new JoystickAxisButtonMapping(1f, 0f, DPAD_HORIZONTAL + numSuffix));
		buttonMappings.Add(JoystickButton.DPadLeft, new JoystickAxisButtonMapping(-1f, 0f, DPAD_HORIZONTAL + numSuffix));
		buttonMappings.Add(JoystickButton.RightShoulder1, new SimpleButtonMapping(KeyCode.Joystick1Button5));
		buttonMappings.Add(JoystickButton.RightShoulder2, new JoystickAxisButtonMapping(1f, 0f, RIGHT_TRIGGER + numSuffix));
		buttonMappings.Add(JoystickButton.LeftShoulder1, new SimpleButtonMapping(KeyCode.Joystick1Button4));
		buttonMappings.Add(JoystickButton.LeftShoulder2, new JoystickAxisButtonMapping(1f, 0f, LEFT_TRIGGER + numSuffix));
		buttonMappings.Add(JoystickButton.LeftStickPress, new SimpleButtonMapping(KeyCode.Joystick1Button8));
		buttonMappings.Add(JoystickButton.RightStickPress, new SimpleButtonMapping(KeyCode.Joystick1Button9));
		buttonMappings.Add(JoystickButton.Start, new SimpleButtonMapping(KeyCode.Joystick1Button7));
		buttonMappings.Add(JoystickButton.Select, new SimpleButtonMapping(KeyCode.Joystick1Button6));

		axisMappings = new Dictionary<JoystickAxis, AxisMapping>();
		axisMappings.Add(JoystickAxis.LeftStickHorizontal, new SimpleAxisMapping(LEFT_STICK_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.LeftStickVertical, new SimpleAxisMapping(LEFT_STICK_VERTICAL + numSuffix));
		axisMappings.Add(JoystickAxis.RightStickHorizontal, new SimpleAxisMapping(RIGHT_STICK_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.RightStickVertical, new SimpleAxisMapping(RIGHT_STICK_VERTICAL + numSuffix));
		axisMappings.Add(JoystickAxis.DPadHorizontal, new SimpleAxisMapping(DPAD_HORIZONTAL + numSuffix));
		axisMappings.Add(JoystickAxis.DPadVertical, new SimpleAxisMapping(DPAD_VERTICAL + numSuffix));
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
