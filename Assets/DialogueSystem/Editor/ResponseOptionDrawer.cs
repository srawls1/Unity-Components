using UnityEditor;

[CustomPropertyDrawer(typeof(ResponseOption))]
public class ResponseOptionDrawer : TypeEditorPropertyDrawer<ResponseOption>
{
	protected override string pathFormat => "Assets/Dialogue/Lines/{0}_{1}.asset";
	protected override string typeName => "ResponseOption";
}
