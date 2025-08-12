using System.Collections;
using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="PropertyFrame{T}"/> that allows to display a <see cref="Key"/>.
    /// </summary>
    public partial class Binder : PropertyFrame<Key>
    {
        #region Serialized

        [SerializeField, ReadOnly]
        private TextButton _keyButton;

        #endregion

        #region Variables

        private KeyCode[] _validKeys;

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="Coroutine"/> that waits until the player presses a valid key,
        /// then updates the current binding accordingly.
        /// </summary>
        /// <returns>Enumerator for Unity's <see cref="Coroutine"/> system.</returns>
        private partial IEnumerator WaitForKeyInput();

        /// <summary>
        /// Changes the current key binding if a valid key was detected.
        /// </summary>
        /// <param name="isKeychanged">Set to true if the binding was updated.</param>
        private partial void ChangeKey(ref bool isKeychanged);

        /// <summary>
        /// Updates the text displayed on the <see cref="TextButton"/> to match the given key.
        /// </summary>
        /// <param name="key">The new key to display.</param>
        private partial void ChangeText(KeyCode key);

        #endregion
    }
}

