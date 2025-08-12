using UnityEditor;

namespace ProjectTemplate
{
    [CustomEditor(typeof(TranslatedText))]
    public class TranslatedText_E : BasicEditor<TranslatedText>
    {
        #region Constantes

        private const string LABEL_PROP_NAME = "_label";
        private const string TEXT_PROP_NAME = "_text";
        private const string TRANSLATIONS_PROP_NAME = "_translations";
        private const string TRANSLATOR_PROP_NAME = "_translator";
        private const string VALUE_PROP_NAME = "_value";

        #endregion

        #region Variables

        private SerializedProperty _label;
        private SerializedProperty _text;
        private SerializedProperty _translator;

        #endregion

        #region Editor Methods

        protected override void GetProperties()
        {
            _label = Get(LABEL_PROP_NAME);
            _text = Get(TEXT_PROP_NAME);
            _translator = Get(TRANSLATOR_PROP_NAME);
        }

        protected override void OnGUI()
        {
            EditorGUILayout.PropertyField(_label);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(_translator);

            if (EditorGUI.EndChangeCheck())
            {
                SerializedProperty translations = _translator.FindPropertyRelative(TRANSLATIONS_PROP_NAME);

                if (translations.arraySize > 0)
                {
                    SerializedProperty defaultTranslation = translations.GetArrayElementAtIndex(0);

                    SerializedProperty value = defaultTranslation.FindPropertyRelative(VALUE_PROP_NAME);

                    _text.stringValue = value.stringValue;

                    serializedObject.ApplyModifiedProperties();

                    EditorUtility.SetDirty(_ref);

                    _ref.DisplayDefaultTranslation();
                }
            }
        }

        #endregion
    }
}