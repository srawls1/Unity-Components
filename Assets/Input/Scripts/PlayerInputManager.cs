using UnityEngine;

public class PlayerInputManager : ScriptableObject
{
    [SerializeField] private ButtonInfo[] buttons;
	[SerializeField] private AxisInfo[] axes;

	public int buttonCount => buttons.Length;
	public int axisCount => axes.Length;

	public ButtonInfo ButtonAt(int i)
	{
		return buttons[i];
	}

	public AxisInfo AxisAt(int i)
	{
		return axes[i];
	}
}
