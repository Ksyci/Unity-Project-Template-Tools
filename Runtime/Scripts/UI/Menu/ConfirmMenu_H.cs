using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// A confirmation <see cref="Menu"/> that displays a warning message and waits for the player
    /// to confirm or cancel an action.
    /// </summary>
    public partial class ConfirmMenu : Menu
    {
        #region Static

        public static UnityEvent<UnityAction, string> OnConfirmRequested;

        #endregion

        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private Button _yesButton;

        [SerializeField, ReadOnly]
        private Button _noButton;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _warningText;

        #endregion

        #region Variables

        private bool _isConfirmed;
        private bool _isValid;

        #endregion

        #region Methods

        /// <summary>
        /// Displays the confirmation menu with the specified warning message,
        /// and waits for the player to confirm or cancel before executing the given action.
        /// </summary>
        /// <param name="action">The action to execute if confirmed.</param>
        /// <param name="warning">The warning message to display.</param>
        /// <returns>An IEnumerator for coroutine execution.</returns>
        private partial IEnumerator ThrowConfirmation(UnityAction action, string warning);

        /// <summary>
        /// Handles the player's confirmation choice and closes the menu.
        /// </summary>
        /// <param name="isValid">True if the action was confirmed, false if cancelled.</param>
        private partial void Confirm(bool isValid);

        #endregion
    }
}