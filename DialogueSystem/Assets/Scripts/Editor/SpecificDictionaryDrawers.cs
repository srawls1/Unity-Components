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

internal class SerializableResponseToNodeTemplate : SerializableKeyValueTemplate<ResponseOption, ConversationNode> { }

[CustomPropertyDrawer(typeof(ResponseToNodeDictionary))]
public class ResponseToNodeDictionaryDrawer : SerializableDictionaryDrawer<ResponseOption, ConversationNode> {
	protected override SerializableKeyValueTemplate<ResponseOption, ConversationNode> GetTemplate()
	{
		return GetGenericTemplate<SerializableResponseToNodeTemplate>();
	}
}