using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(Wave))]
public class WaveDrawer : PropertyDrawer {

    private bool mReduceText = false;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        Rect contentPosition = EditorGUI.PrefixLabel(position, label);
        int originalIndentLevel = EditorGUI.indentLevel;
        
        if (position.height > 60f)
        {
            position.height = 16f;
            //EditorGUI.indentLevel += 1;
            contentPosition = EditorGUI.IndentedRect(position);
            contentPosition.y += 34f;
            EditorGUIUtility.labelWidth = 60f;
        }

        contentPosition.height = 16f;
        EditorGUIUtility.labelWidth = (mReduceText) ? 45f : 140f;
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("TypeOfEnemies"), (mReduceText) ? new GUIContent("TOE", "Type Of Enemies") : new GUIContent("Type Of Enemies", "Type Of Enemies"));

        contentPosition.y += 16f;
        contentPosition.width /= 2;
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("AmountOfEnemies"), (mReduceText) ? new GUIContent("AOE", "Amount Of Enemies") : new GUIContent("Amount Of Enemies", "Amount Of Enemies"));

        contentPosition.x += contentPosition.width;
        EditorGUIUtility.labelWidth = (mReduceText) ? 36f : 82f;
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("StartTime"), (mReduceText) ? new GUIContent("ST", "Start Time Since Last Wave In Seconds") : new GUIContent("Start Time", "Start Time Since Last Wave In Seconds"));

        EditorGUI.EndProperty();
        EditorGUI.indentLevel = originalIndentLevel;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (Screen.width < 677)
        {
            mReduceText = true;
        }
        else
        {
            mReduceText = false;
        }

        return Screen.width < 333 ? 96f : 60f;
    }
}
