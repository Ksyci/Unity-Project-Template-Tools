using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// Main <see cref="Menu"/> providing navigation options.
    /// </summary>
    public partial class MainMenu : Menu
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private Button _startButton;

        [SerializeField, ReadOnly]
        private Button _continueButton;

        [SerializeField, ReadOnly]
        private Button _backupsButton;

        [SerializeField, ReadOnly]
        private Button _settingsButton;

        [SerializeField, ReadOnly]
        private Button _quitButton;

        [Header(Format.EDITABLES_HEADER)]

        [SerializeField]
        private Translator _quitWarning;

        #endregion
    }
}