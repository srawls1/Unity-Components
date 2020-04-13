using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LineNode))]
[CanEditMultipleObjects]
public class LineNodeEditor : Editor
{
	

	public override void OnInspectorGUI()
	{
		//DrawPropertiesExcluding(serializedObject, "result");
		base.OnInspectorGUI();
	}
}
