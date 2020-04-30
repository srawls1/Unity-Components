using System;
using System.Collections.Generic;
using UnityEngine;

public enum KeyboardMouseAxis
{
	MouseX,
	MouseY,
	ScrollWheel,
	WasdHorizontal,
	WasdVertical,
	ArrowHorizontal,
	ArrowVertical
}

public enum JoystickAxis
{
	LeftStickHorizontal,
	LeftStickVertical,
	RightStickHorizontal,
	RightStickVertical,
	DPadHorizontal,
	DPadVertical,
	RightTrigger,
	LeftTrigger
}

[Serializable]
public class AxisInfo
{
    [SerializeField] private string m_defaultMappedAction;
	[SerializeField] private ControllerType m_controllerType;
	[SerializeField] private KeyboardMouseAxis m_keyboardMouseAxis;
	[SerializeField] private JoystickAxis m_joystickAxis;
	[SerializeField] private Sprite m_neutralSprite;
	[SerializeField] private Sprite m_positiveSprite;
	[SerializeField] private Sprite m_negativeSprite;

	public string defaultMappedAction => m_defaultMappedAction;
	public ControllerType controllerType => m_controllerType;
	public KeyboardMouseAxis keyboardMouseAxis => m_keyboardMouseAxis;
	public JoystickAxis joystickAxis => m_joystickAxis;
	public Sprite neutralSprite => m_neutralSprite;
	public Sprite positiveSprite => m_positiveSprite;
	public Sprite negativeSprite => m_negativeSprite;
}
