using UnityEngine;
using System.Collections;
using UnityEditor;

public static class EditorList {

    private static GUIContent
        duplicateButtonContent = new GUIContent("+", "Duplicate"),
        addButtonContent = new GUIContent("Add Wave", "Add Wave"),
        deleteButtonContent = new GUIContent("-", "Delete");

    private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
    public static void Show(SerializedProperty list, string label = "Element")
    {
        EditorGUILayout.PropertyField(list);
        EditorGUI.indentLevel += 1;

        if (list.isExpanded)
        {
            for (int i = 0; i < list.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), new GUIContent(label + " " + (i + 1).ToString()));
                
                ShowButtons(list, i);
                EditorGUILayout.EndHorizontal();
            }
            if (list.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton))
            {
                list.arraySize += 1;
            }
        }

        
        EditorGUI.indentLevel -= 1;
    }

    private static void ShowButtons(SerializedProperty list, int index)
    {
        if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid, miniButtonWidth)) 
        {
            list.InsertArrayElementAtIndex(index);
        }
        
        if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth)) 
        {
            int oldSize = list.arraySize;
            list.DeleteArrayElementAtIndex(index);
            if (list.arraySize == oldSize)
            {
                list.DeleteArrayElementAtIndex(index);
            }
        }
    }
}
