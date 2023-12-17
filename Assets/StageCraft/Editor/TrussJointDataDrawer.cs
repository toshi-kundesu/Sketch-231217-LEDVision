// using UnityEditor;
// using UnityEngine;

// [CustomPropertyDrawer(typeof(TrussJointData))]
// public class TrussJointDataDrawer : PropertyDrawer
// {
//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         label = EditorGUI.BeginProperty(position, label, property);
//         position = EditorGUI.PrefixLabel(position, label);
//         EditorGUI.indentLevel++;

//         SerializedProperty iterator = property.Copy();
//         while (iterator.NextVisible(true))
//         {
//             EditorGUI.PropertyField(position, iterator, true);
//             position.y += EditorGUIUtility.singleLineHeight;
//         }

//         EditorGUI.indentLevel--;
//         EditorGUI.EndProperty();
//     }

//     public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//     {
//         float totalHeight = 0;
//         SerializedProperty iterator = property.Copy();
//         while (iterator.NextVisible(true))
//         {
//             totalHeight += EditorGUIUtility.singleLineHeight;
//         }
//         return totalHeight;
//     }
// }