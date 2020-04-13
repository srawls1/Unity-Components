using System.IO;
using UnityEditor;
using UnityEngine;

public abstract class TypeEditorPropertyDrawer<T> : PropertyDrawer where T : ScriptableObject
{
	protected abstract string typeName { get; }
	protected abstract string pathFormat { get; }

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUILayout.LabelField(label);
		if (property.objectReferenceValue == null)
		{
			CreateLineAsset(property);
		}

		Editor objectEditor = Editor.CreateEditor(property.objectReferenceValue);
		objectEditor.OnInspectorGUI();
	}

	private void CreateLineAsset(SerializedProperty property)
	{
		string assetPath = string.Format(pathFormat, typeName, property.serializedObject.targetObject.GetInstanceID());
		ScriptableObject value = ScriptableObject.CreateInstance(typeof(T));
		EnsureFoldersExist(assetPath);
		AssetDatabase.CreateAsset(value, assetPath);
		AssetDatabase.SaveAssets();
		property.objectReferenceValue = value;
	}

	private void EnsureFoldersExist(string assetPath)
	{
		string[] folders = assetPath.Split('/');
		string parentFolder = folders[0];
		for (int i = 1; i < folders.Length - 1; ++i)
		{
			string pathSoFar = Path.Combine(parentFolder, folders[i]);
			if (AssetDatabase.IsValidFolder(pathSoFar))
			{
				parentFolder = pathSoFar;
			}
			else
			{
				string guid = AssetDatabase.CreateFolder(parentFolder, folders[i]);
				parentFolder = AssetDatabase.GUIDToAssetPath(guid);
			}
		}
	}
}
