using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="PropertyFrame{T}"/> that allows to display a <see cref="Enum"/>.
    /// </summary>
    public partial class Selector : PropertyFrame<Enum>
    {
        #region Serialized

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _state;

        [SerializeField, ReadOnly]
        private Button _backButton;

        [SerializeField, ReadOnly]
        private Button _forwardButton;

        #endregion

        #region Variables

        private Translator[] _enum;

        #endregion

        #region Methods

        /// <summary>
        /// Moves to the next enum value in the list.
        /// </summary>
        private partial void NextState();

        /// <summary>
        /// Moves to the previous enum value in the list.
        /// </summary>
        private partial void LastState();

        /// <summary>
        /// Changes the current state to the enum value at the given index.
        /// </summary>
        /// <param name="index">The index of the enum value to switch to.</param>
        private partial void ChangeState(int index);

        /// <summary>
        /// Updates the displayed text to match the enum value at the given index.
        /// </summary>
        /// <param name="index">The index of the enum value whose label will be shown.</param>
        private partial void ChangeText(int index);

        /// <summary>
        /// Finds the corresponding enum index, wrapping around if necessary.
        /// </summary>
        /// <param name="index">The starting index to check.</param>
        /// <returns>The valid enum index after adjustments.</returns>
        private partial int FindState(int index);

        #endregion
    }
}

