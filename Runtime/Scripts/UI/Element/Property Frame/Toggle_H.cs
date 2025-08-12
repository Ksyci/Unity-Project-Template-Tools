using TMPro;
using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="PropertyFrame{T}"/> that allows to display a <see cref="Boolean"/>.
    /// </summary>
    public partial class Toggle : PropertyFrame<Boolean>
    {
        #region Serialized

        [SerializeField, ReadOnly]
        private UnityEngine.UI.Toggle _state;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _infoText;

        #endregion

        #region Variables

        private Translator _trueText;
        private Translator _falseText;

        #endregion

        #region Methods

        /// <summary>
        /// Sets the toggle state to the given boolean value.
        /// </summary>
        /// <param name="value">The new state to apply (true or false).</param>
        private partial void ChangeState(bool value);

        /// <summary>
        /// Updates the displayed label to match the given toggle state.
        /// </summary>
        /// <param name="value">The state used to determine which text to display.</param>
        private partial void ChangeStateText(bool value);

        #endregion
    }
}