using UnityEngine;
using UnityEditor;
using XNodeEditor;

[CustomNodeEditor(typeof(LineNode))]
public class LineNodeEditor : NodeEditor
{
	public override void OnHeaderGUI()
	{
		GUI.color = Color.white;
		LineNode node = target as LineNode;
		GUILayout.Label(node.character, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
	}

	public override void OnBodyGUI()
	{
		serializedObject.UpdateIfRequiredOrScript();

		SerializedProperty textProperty = serializedObject.FindProperty("m_text");
		NodeEditorGUILayout.PropertyField(textProperty);

		SerializedProperty previousProperty = serializedObject.FindProperty("previous");
		NodeEditorGUILayout.PropertyField(previousProperty);

		SerializedProperty nextProperty = serializedObject.FindProperty("next");
		NodeEditorGUILayout.PropertyField(nextProperty);

		serializedObject.ApplyModifiedProperties();
	}
}
