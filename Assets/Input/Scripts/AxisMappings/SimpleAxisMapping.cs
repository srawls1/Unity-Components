using UnityEngine;

public class SimpleAxisMapping : AxisMapping
{
	private string axisName;

	public SimpleAxisMapping(string axisName)
	{
		this.axisName = axisName;
	}

	public override float value => Input.GetAxisRaw(axisName);
}
