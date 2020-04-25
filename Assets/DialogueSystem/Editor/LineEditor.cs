using System;
using UnityEditor;

[CustomEditor(typeof(LineNode))]
public class LineEditor : Editor
{
	public override void OnInspectorGUI()
	{
		serializedObject.UpdateIfRequiredOrScript();

		LineNode line = target as LineNode;
		Conversation conv = line.graph as Conversation;
		string[] characters = conv.characters;

		SerializedProperty characterProperty = serializedObject.FindProperty("m_character");
		int selectedCharacter = Array.IndexOf(characters, characterProperty.stringValue);
		if (selectedCharacter < 0) selectedCharacter = 0;
		selectedCharacter = EditorGUILayout.Popup("Character", selectedCharacter, characters);
		characterProperty.stringValue = characters[selectedCharacter];

		DrawPropertiesExcluding(serializedObject, "m_Script", "graph", "position", "previous", "next", "m_character");
		serializedObject.ApplyModifiedProperties();
	}
}