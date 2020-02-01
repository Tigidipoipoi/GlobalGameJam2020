using UnityEditor;
using UnityEngine;

namespace GGJ2020.Variables
{
    /// <summary>
    /// The default drawer for every <see cref="VariableReference{TConstantType, TVariableType}"/>.
    /// Since Unity doesn't handle generic for custom drawer, we have to create an explicit drawer inheriting from this for each instance of VariableReference.
    /// </summary>
    public class ReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        readonly string[] m_PopupOptions = { "Use Constant", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        GUIStyle m_PopupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (m_PopupStyle == null)
            {
                m_PopupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                m_PopupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            var useConstant = property.FindPropertyRelative("UseConstant");
            var constantValue = property.FindPropertyRelative("ConstantValue");
            var variable = property.FindPropertyRelative("Variable");

            // Calculate rect for configuration button
            var buttonRect = new Rect(position);
            buttonRect.yMin += m_PopupStyle.margin.top;
            buttonRect.width = m_PopupStyle.fixedWidth + m_PopupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var result = EditorGUI.Popup(
                buttonRect,
                useConstant.boolValue ? 0 : 1, m_PopupOptions,
                m_PopupStyle);

            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(
                position,
                useConstant.boolValue ? constantValue : variable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
