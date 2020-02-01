using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BitMaskAttribute))]
public class BitMaskDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumDisplayNames);
    }
}
