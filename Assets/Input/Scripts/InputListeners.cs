using System;

public class InputListener<Callback> : IComparable<InputListener<Callback>>
{
	public string buttonName { get; private set; }
	public int order { get; private set; }
	public Callback callback { get; private set; }

	public InputListener(string buttonName, int order, Callback callback)
	{
		this.buttonName = buttonName;
		this.order = order;
		this.callback = callback;
	}

	public int CompareTo(InputListener<Callback> other)
	{
		return order - other.order;
	}
}

public delegate bool ButtonCallback();
public class ButtonListener : InputListener<ButtonCallback>
{
	public ButtonListener(string buttonName, int order, ButtonCallback callback)
		: base(buttonName, order, callback) {}
}

public delegate bool AxisCallback(float value);
public class AxisListener : InputListener<AxisCallback>
{
	public AxisListener(string buttonName, int order, AxisCallback callback)
		: base(buttonName, order, callback) {}
}
