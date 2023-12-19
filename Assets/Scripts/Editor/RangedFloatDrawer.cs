using UnityEditor;
using UnityEngine;

namespace SoundSystem
{
    [CustomPropertyDrawer(typeof(RangedFloat), true)]
    public class RangedFloatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            SerializedProperty minProp = property.FindPropertyRelative("MinValue");
            SerializedProperty maxProp = property.FindPropertyRelative("MaxValue");

            float minValue = minProp.floatValue;
            float maxValue = maxProp.floatValue;

            float rangeMin = 0;
            float rangeMax = 1;

            var ranges = (MinMaxRangeAttribute[])fieldInfo.GetCustomAttributes(typeof(MinMaxRangeAttribute), true);
            if (ranges.Length > 0)
            {
                rangeMin = ranges[0].Min;
                rangeMax = ranges[0].Max;
            }

            const float rangeBoundsLabelWidth = 40f;
            const float rangeBoundsLabelWidthDistance = 10f;

            //Draw the min value
            var rangeBoundsLabel1Rect = new Rect(position);
            rangeBoundsLabel1Rect.width = rangeBoundsLabelWidth;
            GUI.Label(rangeBoundsLabel1Rect, new GUIContent(minValue.ToString("F2")));
            position.xMin += rangeBoundsLabelWidth + rangeBoundsLabelWidthDistance;

            //Draw the max value
            var rangeBoundsLabel2Rect = new Rect(position);
            rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - (rangeBoundsLabelWidth + rangeBoundsLabelWidthDistance);
            GUI.Label(rangeBoundsLabel2Rect, new GUIContent(maxValue.ToString("F2")));
            position.xMax -= rangeBoundsLabelWidth + rangeBoundsLabelWidthDistance*2;

            //Draw slider
            EditorGUI.BeginChangeCheck();
            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeMin, rangeMax);
            if (EditorGUI.EndChangeCheck())
            {
                minProp.floatValue = minValue;
                maxProp.floatValue = maxValue;
            }

            EditorGUI.EndProperty();
        }
    }
}