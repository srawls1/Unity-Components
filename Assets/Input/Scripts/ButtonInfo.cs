using System;
using UnityEngine;

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

public enum JoystickButton
{
	SelectFaceButton, // Select and cancel rather than bottom and right,
	CancelFaceButton, // since they are switched on the Switch
	LeftFaceButton,
	TopFaceButton,
	DPadDown,
	DPadUp,
	DPadRight,
	DPadLeft,
	RightShoulder1,
	RightShoulder2,
	LeftShoulder1,
	LeftShoulder2,
	LeftStickPress,
	RightStickPress,
	Start,
	Select
}

[Serializable]
public class ButtonInfo
{
	[SerializeField] private string m_defaultMappedAction;
	[SerializeField] private ControllerType m_controllerType;
	[SerializeField] private KeyCode m_keyCode;
	[SerializeField] private JoystickButton m_button;
	[SerializeField] private Sprite m_buttonImage;

	public string defaultMappedAction => m_defaultMappedAction;
	public ControllerType controllerType => m_controllerType;
	public KeyCode keyCode => m_keyCode;
	public JoystickButton button => m_button;
	public Sprite sprite => m_buttonImage;
}
