using UnityEngine;

public class SimpleTextBoxConversationTarget : MonoBehaviour
{
	[SerializeField] private Conversation conversation;
	[SerializeField] private SimpleTextBoxConversationVisitor textBoxInfo;

	private GenericConversationDriver driver;

    void Awake()
    {
		driver = new GenericConversationDriver(conversation.first, textBoxInfo);
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
