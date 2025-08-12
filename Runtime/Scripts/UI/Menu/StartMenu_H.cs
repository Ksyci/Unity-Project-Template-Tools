using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// Start <see cref="Menu"/> allowing the player to create a new game.
    /// </summary>
    public partial class StartMenu : Menu
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]

        private Field _nameField;

        [SerializeField, ReadOnly]
        private Button _startButton;

        [SerializeField, ReadOnly]
        private Button _returnButton;

        [Header(Format.EDITABLES_HEADER)]

        [SerializeField]
        private String _nameProperty;

        #endregion

        #region Variables

        private Setting _nameSetting;

        #endregion

        #region Methods

        /// <summary>
        /// Start the game and create a new <see cref="Backup"/>
        /// </summary>
        private partial void StartGame();

        #endregion
    }
}