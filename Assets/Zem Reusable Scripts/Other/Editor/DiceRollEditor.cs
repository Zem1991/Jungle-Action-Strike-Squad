using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DiceRoll))]
public class DiceRollEditor : PropertyDrawer
{
    private readonly int valueWidth = 30;
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
        Rect separator2 = new Rect(maximum.x + maximum.width, position.y, separatorWidth, position.height);
        Rect trueMaximum = new Rect(separator2.x + separator2.width, position.y, valueWidth, position.height);

        EditorGUI.PropertyField(value, property.FindPropertyRelative("diceAmount"), GUIContent.none);
        GUI.Label(separator1, "d");
        EditorGUI.PropertyField(maximum, property.FindPropertyRelative("diceSides"), GUIContent.none);
        GUI.Label(separator2, "+");
        EditorGUI.PropertyField(trueMaximum, property.FindPropertyRelative("addedValue"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
