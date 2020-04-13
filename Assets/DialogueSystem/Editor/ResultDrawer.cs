using UnityEditor;

[CustomPropertyDrawer(typeof(ConversationResult))]
public class ResultDrawer : SelectableSubtypePropertyDrawer<ConversationResult>
{
	protected override string defaultSubtype => "NullConversationResult";
	protected override string pathFormat => "Assets/Dialogue/ConversationResults/{0}_{1}.asset";
}
