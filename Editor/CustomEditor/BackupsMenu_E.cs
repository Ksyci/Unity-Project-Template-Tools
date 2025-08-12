using UnityEditor;

namespace ProjectTemplate
{
    [CustomEditor(typeof(BackupsMenu))]
    public class BackupsMenu_E : BasicEditor<BackupsMenu>
    {
        #region Editor Methods

        protected override void GetProperties() { }

        protected override void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            BaseInspector();

            if (EditorGUI.EndChangeCheck())
            {
                _ref.MakeGrid();
            }
        }

        #endregion
    }
}