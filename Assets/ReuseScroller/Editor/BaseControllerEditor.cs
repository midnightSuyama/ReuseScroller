using UnityEditor;

namespace ReuseScroller
{
	[CustomEditor(typeof(BaseController<>), true)]
	public class BaseControllerEditor : Editor
	{
		public override void OnInspectorGUI() {
			serializedObject.Update();
			DrawPropertiesExcluding(serializedObject, "m_Script");
			serializedObject.ApplyModifiedProperties();
		}
	}
}
