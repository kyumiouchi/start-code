using UnityEditor;
using UnityEngine;

namespace SoundSystem
{
    [CustomEditor(typeof(SoundEventSo), true)]
    public class SoundEventEditor : Editor
    {
        [SerializeField] private AudioSource _audioPreviewer;

        private void OnEnable()
        {
            _audioPreviewer = EditorUtility.CreateGameObjectWithHideFlags("Audio Preview", 
                    HideFlags.HideAndDontSave, typeof(AudioSource))
                .GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            DestroyImmediate(_audioPreviewer.gameObject);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DrawPreviewButton();
        }

        private void DrawPreviewButton()
        {
            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

            GUILayout.Space(20);
            if (GUILayout.Button("Audio Preview", GUILayout.Height(100)))
            {
                ((SoundEventSo)target).Preview(_audioPreviewer);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}
