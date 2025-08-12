using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// Pause <see cref="Menu"/> providing navigation options.
    /// </summary>
    public partial class PauseMenu : Menu
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private Button _backupsButton;

        [SerializeField, ReadOnly]
        private Button _settingsButton;

        [SerializeField, ReadOnly]
        private Button _mainMenuButton;

        [Header(Format.EDITABLES_HEADER)]

        [SerializeField]
        private Translator _quitWarning;

        #endregion

        #region Properties

        private string QuitWarning => _quitWarning[LanguagesManager.Instance.ActiveLanguage];

        #endregion

        #region Methods

        /// <summary>
        /// Allows the player to quit to the main menu <see cref="GameScene"/>.
        /// </summary>
        private partial void Quit();

        #endregion
    }
}