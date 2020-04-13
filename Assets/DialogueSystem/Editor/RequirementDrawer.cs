using UnityEditor;

[CustomPropertyDrawer(typeof(Requirement))]
public class RequirementDrawer : SelectableSubtypePropertyDrawer<Requirement>
{
	protected override string defaultSubtype => "NullRequirement";
	protected override string pathFormat => "Assets/Dialogue/Requirements/{0}_{1}.asset";
}
