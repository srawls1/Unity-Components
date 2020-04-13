using System;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEditor;

public abstract class SelectableSubtypePropertyDrawer<T> : PropertyDrawer where T : ScriptableObject
{
	protected abstract string pathFormat { get; }
    protected abstract string defaultSubtype { get; }

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		HandleType(property, label);
		Editor objectEditor = Editor.CreateEditor(property.objectReferenceValue);
		objectEditor.OnInspectorGUI();
	}

	private void HandleType(SerializedProperty property, GUIContent label)
	{
		string[] subclasses = GetSubclasses();
		int selectedType = GetSelectedType(subclasses, property);
		int newlySelectedType = EditorGUILayout.Popup(label, selectedType, subclasses);
		if (newlySelectedType == selectedType)
		{
			return;
		}

		int objectCode = property.serializedObject.targetObject.GetInstanceID();
		string typeName = subclasses[newlySelectedType];
		property.objectReferenceValue = LoadOrCreateAsset(typeName, objectCode);
	}

	private string[] GetSubclasses()
	{
		Type baseResultType = typeof(T);
		return baseResultType.Assembly.GetTypes()
			.Where((type) => type.BaseType == baseResultType)
			.Select((type) => type.Name)
			.ToArray();
	}

	private int GetSelectedType(string[] types, SerializedProperty property)
	{
		if (property.objectReferenceValue == null)
		{
			property.objectReferenceValue = LoadOrCreateAsset(defaultSubtype, 0);
		}
		string type = property.objectReferenceValue.GetType().Name;
		return Array.IndexOf(types, type);
	}

	private ScriptableObject LoadOrCreateAsset(string typeName, int ownerCode)
	{
		string assetPath = string.Format(pathFormat, typeName, ownerCode);
		Type assetType = typeof(T).Assembly.GetType(typeName);
		ScriptableObject value = AssetDatabase.LoadAssetAtPath(assetPath, assetType) as ScriptableObject;

		if (value == null)
		{
			value = ScriptableObject.CreateInstance(assetType);
			EnsureFoldersExist(assetPath);
			AssetDatabase.CreateAsset(value, assetPath);
			AssetDatabase.SaveAssets();
		}
		return value;
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
