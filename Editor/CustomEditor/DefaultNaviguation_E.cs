using UnityEditor;

namespace ProjectTemplate
{
    [CustomEditor(typeof(DefaultNaviguation))]
    public class DefaultNaviguation_E : BasicEditor<DefaultNaviguation>
    {
        #region Constantes

        private const float MAX_SENSITIVITY = 5.0f;
        private const float MAX_VELOCITY = 10.0f;
        private const float MIN_SENSITIVITY = 1.0f;
        private const float MIN_VELOCITY = 1.0f;


        private const string SETTINGS_SECTION_NAME = "Settings";
        private const string EVENTS_PROP_NAME = "_events";
        private const string EVENTS_SECTION_NAME = "Events";
        private const string SENSITIVITY_PROP_NAME = "_sensitivity";
        private const string VELOCITY_PROP_NAME = "_velocity";


        #endregion

        #region Variables

        SerializedProperty _events;
        SerializedProperty _sensitivity;
        SerializedProperty _velocity;

        #endregion

        #region Editor Methods

        protected override void GetProperties()
        {
            _events = Get(EVENTS_PROP_NAME);
            _sensitivity = Get(SENSITIVITY_PROP_NAME);
            _velocity = Get(VELOCITY_PROP_NAME);
        }

        protected override void OnGUI()
        {
            Edition.CreateSection(SETTINGS_SECTION_NAME, DisplaySettings, false);
            Edition.CreateSection(EVENTS_SECTION_NAME, DisplayEvents, false);

        }

        #endregion

        #region Other Methods

        private void DisplaySettings()
        {
            string title = Format.Polish(nameof(_ref.Velocity));
            _velocity.floatValue = EditorGUILayout.Slider(title, _velocity.floatValue, MIN_VELOCITY, MAX_VELOCITY);

            title = Format.Polish(nameof(_ref.Sensitivity));
            _sensitivity.floatValue = EditorGUILayout.Slider(title, _sensitivity.floatValue, MIN_SENSITIVITY, MAX_SENSITIVITY);
        }

        private void DisplayEvents()
        {
            int index = 0;

            DisplayKeyEvent(DefaultNaviguation.PAUSE_EVENT_NAME, ref index);
            DisplayKeyEvent(DefaultNaviguation.FORMWARD_EVENT_NAME, ref index);
            DisplayKeyEvent(DefaultNaviguation.BACK_EVENT_NAME, ref index);
            DisplayKeyEvent(DefaultNaviguation.LEFT_EVENT_NAME, ref index);
            DisplayKeyEvent(DefaultNaviguation.RIGHT_EVENT_NAME, ref index);
        }

        private void DisplayKeyEvent(string name, ref int index)
        {
            if (index >= _events.arraySize)
            {
                _events.arraySize++;
                _events.serializedObject.ApplyModifiedProperties();
            }

            var movement = _events.GetArrayElementAtIndex(index);

            if (movement.managedReferenceValue == null)
            {
                movement.managedReferenceValue = new KeyEvent(name);
            }
            else
            {
                KeyEvent keyEvent = movement.managedReferenceValue as KeyEvent;
                keyEvent.Name = name;
                movement.managedReferenceValue = keyEvent;
            }

            _events.serializedObject.ApplyModifiedProperties();

            Edition.CreateProperty(movement, name);

            ++index;
        }

        #endregion
    }
}