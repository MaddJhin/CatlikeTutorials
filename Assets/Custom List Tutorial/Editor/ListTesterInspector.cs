using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ListTester))]
public class ListTesterInspector : Editor {

	public override void OnInspectorGUI () {
		serializedObject.Update ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("integers"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("vectors"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("colorPoints"), true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("objects"), true);
		serializedObject.ApplyModifiedProperties ();
	}

}