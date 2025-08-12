using TMPro;
using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// UI element that displays localized text using a Translator,
    /// with support for a default text and additional appended text.
    /// </summary>
    public partial class TranslatedText : UIElement
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _label;

        [SerializeField]
        private string _text;

        [SerializeField]
        private Translator _translator;

        #endregion

        #region Variables

        private string _additiveText;

        #endregion

        #region Methods

        /// <summary>
        /// Adds additional text to the current label content.
        /// </summary>
        /// <param name="text">The text to add.</param>
        public partial void AddText(string text);

        /// <summary>
        /// Displays the default translation text in the label.
        /// </summary>
        public partial void DisplayDefaultTranslation();

        /// <summary>
        /// Displays the translated text based on the current translator.
        /// </summary>
        public partial void DisplayTranslation();

        #endregion
    }
}