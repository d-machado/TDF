using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WaveController))]
public class WaveControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorList.Show(serializedObject.FindProperty("Waves"), "Wave");
        serializedObject.ApplyModifiedProperties();
    }
	
}
