using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputProxy : MonoBehaviour
{
	private Dictionary<string, PriorityQueue<ButtonListener>> registeredPressListeners;
	private Dictionary<string, PriorityQueue<ButtonListener>> registeredHoldListeners;
	private Dictionary<string, PriorityQueue<ButtonListener>> registeredReleaseListeners;
	private Dictionary<string, PriorityQueue<AxisListener>> registeredAxisListeners;

	protected void Awake()
	{
		registeredPressListeners = new Dictionary<string, PriorityQueue<ButtonListener>>();
		registeredHoldListeners = new Dictionary<string, PriorityQueue<ButtonListener>>();
		registeredReleaseListeners = new Dictionary<string, PriorityQueue<ButtonListener>>();
		registeredAxisListeners = new Dictionary<string, PriorityQueue<AxisListener>>();
	}

	protected void Update()
	{
		IterateButtonListenerList(registeredPressListeners, GetButtonDown);
		IterateButtonListenerList(registeredHoldListeners, GetButton);
		IterateButtonListenerList(registeredReleaseListeners, GetButtonUp);
		IterateAxisListenerList(registeredAxisListeners);
	}

	public ButtonListener RegisterPressListener(string buttonName, int order, ButtonCallback callback)
	{
		ButtonListener listener = new ButtonListener(buttonName, order, callback);
		AddListenerToQueue<ButtonListener, ButtonCallback>(registeredPressListeners, listener);
		return listener;
	}

	public void DeregisterPressListener(ButtonListener listener)
	{
		RemoveListenerFromQueue<ButtonListener, ButtonCallback>(registeredPressListeners, listener);
	}

	public ButtonListener RegisterHoldListener(string buttonName, int order, ButtonCallback callback)
	{
		ButtonListener listener = new ButtonListener(buttonName, order, callback);
		AddListenerToQueue<ButtonListener, ButtonCallback>(registeredHoldListeners, listener);
		return listener;
	}

	public void DeregisterHoldListener(ButtonListener listener)
	{
		RemoveListenerFromQueue<ButtonListener, ButtonCallback>(registeredHoldListeners, listener);
	}

	public ButtonListener RegisterReleaseListener(string buttonName, int order, ButtonCallback callback)
	{
		ButtonListener listener = new ButtonListener(buttonName, order, callback);
		AddListenerToQueue<ButtonListener, ButtonCallback>(registeredReleaseListeners, listener);
		return listener;
	}

	public void DeregisterReleaseListener(ButtonListener listener)
	{
		RemoveListenerFromQueue<ButtonListener, ButtonCallback>(registeredReleaseListeners, listener);
	}

	public AxisListener RegisterAxisListener(string buttonName, int order, AxisCallback callback)
	{
		AxisListener listener = new AxisListener(buttonName, order, callback);
		AddListenerToQueue<AxisListener, AxisCallback>(registeredAxisListeners, listener);
		return listener;
	}

	public void DeregisterAxisListener(AxisListener listener)
	{
		RemoveListenerFromQueue<AxisListener, AxisCallback>(registeredAxisListeners, listener);
	}

	public virtual float GetAxis(string axisName)
	{
		return Input.GetAxis(axisName);
	}

	public virtual bool GetButton(string buttonName)
	{
		return Input.GetButton(buttonName);
	}

	public virtual bool GetButtonDown(string buttonName)
	{
		return Input.GetButtonDown(buttonName);
	}

	public virtual bool GetButtonUp(string buttonName)
	{
		return Input.GetButtonUp(buttonName);
	}

	private void IterateButtonListenerList(Dictionary<string, PriorityQueue<ButtonListener>> listeners,
		Func<string, bool> condition)
	{
		foreach (KeyValuePair<string, PriorityQueue<ButtonListener>> mapping in listeners)
		{
			if (condition(mapping.Key))
			{
				foreach (ButtonListener listener in mapping.Value)
				{
					if (listener.callback())
					{
						break;
					}
				}
			}
		}
	}

	private void IterateAxisListenerList(Dictionary<string, PriorityQueue<AxisListener>> listeners)
	{
		foreach (KeyValuePair<string, PriorityQueue<AxisListener>> mapping in listeners)
		{
			float value = GetAxis(mapping.Key);
			foreach (AxisListener listener in mapping.Value)
			{
				if (listener.callback(value))
				{
					break;
				}
			}
		}
	}

	private void AddListenerToQueue<T, C>(Dictionary<string, PriorityQueue<T>> listeners,
		T listener) where T : InputListener<C>
	{
		PriorityQueue<T> queue;
		if (!listeners.TryGetValue(listener.buttonName, out queue))
		{
			queue = new LinkedListPriorityQueue<T>();
			listeners.Add(listener.buttonName, queue);
		}

		queue.Add(listener);
	}

	private void RemoveListenerFromQueue<T, C>(Dictionary<string, PriorityQueue<T>> listeners,
		T listener) where T : InputListener<C>
	{
		PriorityQueue<T> queue = listeners[listener.buttonName];
		queue.Remove(listener);
	}
}
