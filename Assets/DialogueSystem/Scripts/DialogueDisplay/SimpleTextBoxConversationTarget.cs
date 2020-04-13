using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTextBoxConversationTarget : MonoBehaviour
{
	[SerializeField] private ConversationNode firstNode;
	[SerializeField] private SimpleTextBoxConversationVisitor textBoxInfo;

	private GenericConversationDriver driver;

    void Awake()
    {
		driver = new GenericConversationDriver(firstNode, textBoxInfo);
	}

	//<temp>
	private void Start()
	{
		StartConversation();
	}
	//</temp>

	public Coroutine StartConversation()
	{
		return StartCoroutine(driver.ConversationRoutine());
	}
}
