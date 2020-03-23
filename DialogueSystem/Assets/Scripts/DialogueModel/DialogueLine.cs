using System;
using UnityEngine;

[Serializable]
public class SerializableStringDictionary : SerializableDictionary<string, string> {}

[CreateAssetMenu]
public class DialogueLine : ScriptableObject
{
    [SerializeField] private string m_text;
	[SerializeField] private string m_character;
	[SerializeField] private AudioClip m_audio;
	[SerializeField] private Animation m_animation;
	[SerializeField] private SerializableStringDictionary m_attributes;

	public string text { get { return m_text; } }
	public string character { get { return m_character; } }
	public bool hasAudio { get { return m_audio != null; } }
	public AudioClip audio { get { return m_audio; } }
	public bool hasAnimation { get { return m_animation != null; } }
	public Animation animation { get { return m_animation; } }

	public bool HasAttribute(string key)
	{
		return m_attributes.ContainsKey(key);
	}

	public string GetAttribute(string key)
	{
		return m_attributes[key];
	}
}
