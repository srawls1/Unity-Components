using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public abstract class SerializableValueTemplate<T> : ScriptableObject
{
	public T value;
}

public abstract class SerializableSetDrawer<T> : PropertyDrawer
{
	protected abstract SerializableValueTemplate<T> GetTemplate();
	protected R GetGenericTemplate<R>() where R : SerializableValueTemplate<T>
	{
		return ScriptableObject.CreateInstance<R>();
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		var firstLine = position;
		firstLine.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(firstLine, property);

		if (property.isExpanded)
		{
			var secondLine = firstLine;
			secondLine.y += EditorGUIUtility.singleLineHeight;

			EditorGUIUtility.labelWidth = 50f;

			secondLine.x += 15f; // indentation
			secondLine.width -= 15f;

			var buttonWidth = 60f;

			var secondLine_value = secondLine;
			secondLine_value.x += secondLine_value.width;
			if (GetTemplateProp(property).hasVisibleChildren)
			{ // if the value has children, indent to make room for fold arrow
				secondLine_value.x += 15;
				secondLine_value.width -= 15;
			}

			var secondLine_button = secondLine_value;
			secondLine_button.x += secondLine_value.width;
			secondLine_button.width = buttonWidth;

			var vHeight = EditorGUI.GetPropertyHeight(GetTemplateProp(property));
			secondLine_value.height = vHeight;

			EditorGUI.PropertyField(secondLine_value, GetTemplateProp(property), true);

			var valuesProp = GetValuesProp(property);
			var numLines = valuesProp.arraySize;

			if (GUI.Button(secondLine_button, "Assign"))
			{
				bool assignment = false;
				for (int i = 0; i < numLines; i++)
				{ // Try to replace existing value
					if (SerializedPropertyExtension.EqualBasics(GetIndexedItemProp(valuesProp, i), GetTemplateProp(property)))
					{
						SerializedPropertyExtension.CopyBasics(GetTemplateProp(property), GetIndexedItemProp(valuesProp, i));
						assignment = true;
						break;
					}
				}
				if (!assignment)
				{ // Create a new value
					valuesProp.arraySize += 1;
					SerializedPropertyExtension.CopyBasics(GetTemplateProp(property), GetIndexedItemProp(valuesProp, numLines));
				}
			}

			for (int i = 0; i < numLines; i++)
			{
				secondLine_value.y += vHeight;
				secondLine_button.y += vHeight;

				vHeight = EditorGUI.GetPropertyHeight(GetIndexedItemProp(valuesProp, i));

				secondLine_value.height = vHeight;

				EditorGUI.PropertyField(secondLine_value, GetIndexedItemProp(valuesProp, i), true);

				if (GUI.Button(secondLine_button, "Remove"))
				{
					valuesProp.DeleteArrayElementAtIndex(i);
				}
			}
		}
		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		if (!property.isExpanded)
			return EditorGUIUtility.singleLineHeight;

		var total = EditorGUIUtility.singleLineHeight;

		var vHeight = EditorGUI.GetPropertyHeight(GetTemplateProp(property));

		var valuesProp = GetValuesProp(property);
		int numLines = valuesProp.arraySize;
		for (int i = 0; i < numLines; i++)
		{
			vHeight = EditorGUI.GetPropertyHeight(GetIndexedItemProp(valuesProp, i));
			total += vHeight;
		}
		return total;
	}

	private SerializedProperty GetTemplateProp(SerializedProperty mainProp)
	{
		SerializedProperty p;
		if (!templateValueProp.TryGetValue(mainProp.GetObjectCode(), out p))
		{
			var templateObject = GetTemplate();
			var templateSerializedObject = new SerializedObject(templateObject);
			var vProp = templateSerializedObject.FindProperty("value");
			templateValueProp[mainProp.GetObjectCode()] = vProp;
			p = vProp;
		}
		return p;
	}
	private Dictionary<int, SerializedProperty> templateValueProp = new Dictionary<int, SerializedProperty>();
	
	private SerializedProperty GetValuesProp(SerializedProperty mainProp)
	{
		return GetCachedProp(mainProp, "values", valuesProps);
	}

	private SerializedProperty GetCachedProp(SerializedProperty mainProp, string relativePropertyName, Dictionary<int, SerializedProperty> source)
	{
		SerializedProperty p;
		int objectCode = mainProp.GetObjectCode();
		if (!source.TryGetValue(objectCode, out p))
			source[objectCode] = p = mainProp.FindPropertyRelative(relativePropertyName);
		return p;
	}

	private Dictionary<int, SerializedProperty> valuesProps = new Dictionary<int, SerializedProperty>();

	private Dictionary<int, Dictionary<int, SerializedProperty>> indexedPropertyDicts = new Dictionary<int, Dictionary<int, SerializedProperty>>();

	private SerializedProperty GetIndexedItemProp(SerializedProperty arrayProp, int index)
	{
		Dictionary<int, SerializedProperty> d;
		if (!indexedPropertyDicts.TryGetValue(arrayProp.GetObjectCode(), out d))
			indexedPropertyDicts[arrayProp.GetObjectCode()] = d = new Dictionary<int, SerializedProperty>();
		SerializedProperty result;
		if (!d.TryGetValue(index, out result))
			d[index] = result = arrayProp.FindPropertyRelative(string.Format("Array.data[{0}]", index));
		return result;
	}

}
