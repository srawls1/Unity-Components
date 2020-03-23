using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ResponseOption : DialogueLine
{
	[SerializeField] Requirement m_requirement;

	public Requirement requirement { get { return m_requirement; } }
}
