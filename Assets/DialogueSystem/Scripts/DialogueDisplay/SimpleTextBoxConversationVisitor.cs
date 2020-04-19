using System.Collections;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SimpleTextBoxConversationVisitor : ConversationVisitor
{
	[SerializeField] private Text textBox;
	[SerializeField] private RectTransform choiceRect;
	[SerializeField] private Button choiceButtonPrefab;
	[SerializeField] private float timePerCharacter;

	public IEnumerator VisitChoice(ChoiceNode node)
	{
		ReadOnlyCollection<LineNode> options = node.GetPossibleResponses();
		for (int i = 0; i < options.Count; ++i)
		{
			LineNode option = options[i];
			Button butt = Object.Instantiate(choiceButtonPrefab, choiceRect);
			Text choiceText = butt.GetComponentInChildren<Text>();
			choiceText.text = option.text;
			butt.onClick.AddListener(() => SelectOption(option));
		}
		choiceRect.gameObject.SetActive(true);

		yield return new WaitWhile(() => choice == null);
		node.SetResponse(choice);

		choice = null;
		// TODO - reuse buttons; just disable and re-enable
		for (int i = 0; i < choiceRect.childCount; ++i)
		{
			Object.Destroy(choiceRect.GetChild(i).gameObject);
		}
		choiceRect.gameObject.SetActive(false);
	}

	public IEnumerator VisitLine(LineNode node)
	{
		textBox.text = node.character + ": ";

		string text = node.text;
		if (timePerCharacter <= 0f)
		{
			textBox.text += text;
			yield break;
		}

		for (int i = 0; i < text.Length; ++i)
		{
			textBox.text += text[i];
			yield return new WaitForSeconds(timePerCharacter);
		}
	}

	private LineNode choice = null;
	private void SelectOption(LineNode option)
	{
		choice = option;
	}
}
