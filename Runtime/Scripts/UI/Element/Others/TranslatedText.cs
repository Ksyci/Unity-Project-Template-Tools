namespace ProjectTemplate
{
    public partial class TranslatedText : UIElement
    {
        #region Unity Methods

        private void Start() => LanguagesManager.Instance.BindAndApply(DisplayTranslation);

        #endregion

        #region Public Methods

        public partial void DisplayDefaultTranslation()
            => _label.text = _text;

        public partial void DisplayTranslation()
            => _label.text = _translator[LanguagesManager.Instance.ActiveLanguage] + _additiveText;

        public partial void AddText(string text)
        {
            _additiveText = text;

            DisplayTranslation();
        }

        #endregion
    }
}