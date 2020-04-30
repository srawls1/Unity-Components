using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInputProxy : PlayerInputProxy
{
	private static Dictionary<KeyboardMouseAxis, AxisMapping> axisMappings;

	static KeyBoardInputProxy()
	{
		axisMappings = new Dictionary<KeyboardMouseAxis, AxisMapping>();
		axisMappings.Add(KeyboardMouseAxis.MouseX, new SimpleAxisMapping("Mouse X"));
		axisMappings.Add(KeyboardMouseAxis.MouseY, new SimpleAxisMapping("Mouse Y"));
		axisMappings.Add(KeyboardMouseAxis.ScrollWheel, new SimpleAxisMapping("Mouse ScrollWheel"));
		axisMappings.Add(KeyboardMouseAxis.WasdHorizontal, new ButtonAxisMapping(KeyCode.D, KeyCode.A));
		axisMappings.Add(KeyboardMouseAxis.WasdVertical, new ButtonAxisMapping(KeyCode.W, KeyCode.S));
		axisMappings.Add(KeyboardMouseAxis.ArrowHorizontal, new ButtonAxisMapping(KeyCode.RightArrow, KeyCode.LeftArrow));
	}

	public override ControllerType controllerType => ControllerType.KeyboardAndMouse;

	protected override AxisMapping convertAxisInfoToMapping(AxisInfo info)
	{
		return axisMappings[info.keyboardMouseAxis];
	}

	protected override ButtonMapping convertButtonInfoToMapping(ButtonInfo info)
	{
		return new SimpleButtonMapping(info.keyCode);
	}
}
