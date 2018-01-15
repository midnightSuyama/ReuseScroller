using UnityEditor;

namespace ReuseScroller
{
	[CustomEditor(typeof(BaseCell<>), true)]
	public class BaseCellEditor : Editor
	{
		public override void OnInspectorGUI() {
			serializedObject.Update();
			DrawPropertiesExcluding(serializedObject, "m_Script");
			serializedObject.ApplyModifiedProperties();
		}
	}
}
