using TMPro;
using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="PropertyFrame{T}"/> that allows to display a <see cref="String"/>.
    /// </summary>
    public partial class Field : PropertyFrame<String>
    {
        #region Serialized

        [SerializeField, ReadOnly]
        private TMP_InputField _inputField;

        #endregion

        #region Variables

        private Format.Type _format;

        private int _maxCharacters;

        #endregion

        #region Methods

        /// <summary>
        /// Changes the displayed text to the specified value.
        /// </summary>
        /// <param name="value">The new text value to display.</param>
        private partial void ChangeText(string value);

        /// <summary>
        /// Validates the specified text value according to a <see cref="Format.Type"/>.
        /// </summary>
        /// <param name="value">The text value to validate.</param>
        private partial void Validate(string value);

        #endregion
    }
}