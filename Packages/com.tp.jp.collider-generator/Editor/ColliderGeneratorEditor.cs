using UnityEditor;
using UnityEngine;

namespace TpLab.ColliderGenerator.Editor
{
    [CustomEditor(typeof(ColliderGenerator))]
    public class ColliderGeneratorEditor : UnityEditor.Editor
    {
        struct SerializedProperties
        {
            public SerializedProperty layoutSizeX;
            public SerializedProperty layoutSizeZ;
            public SerializedProperty layoutCount;
            public SerializedProperty colliderThickness;
            public SerializedProperty colliderHeight;
            public SerializedProperty colliderEdgeLength;
            public SerializedProperty colliderNameFormat;

            public SerializedProperties(SerializedObject serializedObject)
            {
                layoutSizeX = serializedObject.FindProperty(nameof(ColliderGenerator.layoutSizeX));
                layoutSizeZ = serializedObject.FindProperty(nameof(ColliderGenerator.layoutSizeZ));
                layoutCount = serializedObject.FindProperty(nameof(ColliderGenerator.layoutCount));
                colliderThickness = serializedObject.FindProperty(nameof(ColliderGenerator.colliderThickness));
                colliderHeight = serializedObject.FindProperty(nameof(ColliderGenerator.colliderHeight));
                colliderEdgeLength = serializedObject.FindProperty(nameof(ColliderGenerator.colliderEdgeLength));
                colliderNameFormat = serializedObject.FindProperty(nameof(ColliderGenerator.colliderNameFormat));
            }
        }

        ColliderGenerator _target;
        SerializedProperties _props;
        bool _isExpandLayout = true;
        bool _isExpandCollider = true;

        void OnEnable()
        {
            _target = target as ColliderGenerator;
            _props = new SerializedProperties(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _isExpandLayout = EditorGUILayout.Foldout(_isExpandLayout, "Layout Info");
            if (_isExpandLayout)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    EditorGUILayout.PropertyField(_props.layoutSizeX);
                    EditorGUILayout.PropertyField(_props.layoutSizeZ);
                    EditorGUILayout.PropertyField(_props.layoutCount);
                }
            }
            EditorGUILayout.Space();

            _isExpandCollider = EditorGUILayout.Foldout(_isExpandCollider, "Collider Info");
            if (_isExpandCollider)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    EditorGUILayout.PropertyField(_props.colliderThickness);
                    EditorGUILayout.PropertyField(_props.colliderHeight);
                    EditorGUILayout.PropertyField(_props.colliderEdgeLength);
                    EditorGUILayout.LabelField(" ", "0の場合は自動で計算する");
                    EditorGUILayout.DelayedTextField(_props.colliderNameFormat);
                }
            }
            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Clear"))
                {
                    _target.ClearBoxColliders();
                }
                if (GUILayout.Button("Generate"))
                {
                    _target.GenerateBoxColliders();
                }
            }

            if (serializedObject.ApplyModifiedProperties())
            {
                // コライダー名書式に{0}が含まれていない場合は追加する
                if (!_props.colliderNameFormat.stringValue.Contains("{0}"))
                {
                    _props.colliderNameFormat.stringValue = _props.colliderNameFormat.stringValue + "{0}";
                    serializedObject.ApplyModifiedProperties();
                }
            }
        }
    }
}
