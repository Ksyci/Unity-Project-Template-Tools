using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// Represents a UI button with a text label, allowing binding of click events.
    /// </summary>
    public partial class TextButton : UIElement
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _label;

        [SerializeField, ReadOnly]
        private Button _button;

        #endregion

        #region Properties

        public string Text { get => _label.text; set => _label.text = value; }

        #endregion

        #region Methods

        /// <summary>
        /// Binds a <see cref="UnityAction"/> to be invoked when the <see cref="Button"/> is clicked.
        /// </summary>
        /// <param name="action">The callback to invoke on button click.</param>
        public partial void Bind(UnityAction action);

        #endregion
    }
}