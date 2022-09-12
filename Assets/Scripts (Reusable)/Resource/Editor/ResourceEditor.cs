using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Resource))]
public class ResourceDrawer : PropertyDrawer
{
    private readonly int valueWidth = 50;
    private readonly int separatorWidth = 10;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect value = new Rect(position.x, position.y, valueWidth, position.height);
        Rect separator1 = new Rect(value.x + value.width, position.y, separatorWidth, position.height);
        Rect maximum = new Rect(separator1.x + separator1.width, position.y, valueWidth, position.height);

        EditorGUI.PropertyField(value, property.FindPropertyRelative("current"), GUIContent.none);
        GUI.Label(separator1, "/");
        EditorGUI.PropertyField(maximum, property.FindPropertyRelative("maximum"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
