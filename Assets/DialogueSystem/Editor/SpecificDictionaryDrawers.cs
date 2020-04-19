using UnityEditor;

internal class SerializableStringStringTemplate : SerializableKeyValueTemplate<string, string> { }

[CustomPropertyDrawer(typeof(SerializableStringDictionary))]
public class SerializableStringDictionaryDrawer : SerializableDictionaryDrawer<string, string>
{
	protected override SerializableKeyValueTemplate<string, string> GetTemplate()
	{
		return GetGenericTemplate<SerializableStringStringTemplate>();
	}
}
