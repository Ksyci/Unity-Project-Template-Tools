using System.Linq;
using UnityEditor;

namespace ProjectTemplate
{
    #if UNITY_EDITOR

    [CustomEditor(typeof(Audio))]
    public class Audio_E : BasicEditor<Audio>
    {
        #region Constantes

        private const string CLIPS_PROP_NAME = "_clips";
        private const string SOURCE_PROP_NAME = "_source";
        private const string TYPE_PROP_NAME = "_type";

        #endregion

        #region Variables

        private SerializedProperty _clips;
        private SerializedProperty _source;
        private SerializedProperty _type;

        #endregion

        #region Editor Methods

        protected override void GetProperties()
        {
            _type = serializedObject.FindProperty(TYPE_PROP_NAME);
            _source = serializedObject.FindProperty(SOURCE_PROP_NAME);
            _clips = serializedObject.FindProperty(CLIPS_PROP_NAME);
        }

        protected override void OnGUI()
        {
            string name = Format.Polish(nameof(Audio));

            Edition.CreateSection(name, Display, false);
        }

        #endregion

        #region Other Methods

        private void Display()
        {
            string title = Format.Polish(nameof(_ref.Type));
            Edition.CreateProperty(_type, title);

            title = Format.Polish(nameof(_ref.Source));
            Edition.CreateProperty(_source, title);

            if (_type.enumValueIndex == (int)Audio.Category.VOICE)
            {
                DisplayMultipleClips();
            }
            else
            {
                DisplaySingleClip();
            }
        }

        private void DisplayMultipleClips()
        {
            _clips.arraySize = ProjectProperties.Get().Languages.Count;

            for (int i = 0; i < _clips.arraySize; i++)
            {
                SerializedProperty clip = _clips.GetArrayElementAtIndex(i);

                string title = General.FindAt(ProjectProperties.Get().Languages.ToList(), i);

                Edition.CreateProperty(clip, title);
            }
        }

        private void DisplaySingleClip()
        {
            _clips.arraySize = 1;

            SerializedProperty clip = _clips.GetArrayElementAtIndex(0);

            string title = Format.Polish(nameof(_ref.Clips));
            Edition.CreateProperty(clip, title);
        }

        #endregion
    }

    #endif
}