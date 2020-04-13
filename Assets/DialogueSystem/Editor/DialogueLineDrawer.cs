using UnityEditor;

[CustomPropertyDrawer(typeof(DialogueLine))]
public class DialogueLineDrawer : TypeEditorPropertyDrawer<DialogueLine>
{
	protected override string typeName => "DialogueLine";
	protected override string pathFormat => "Assets/Dialogue/Lines/{0}_{1}.asset";
}
