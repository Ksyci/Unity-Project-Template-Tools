namespace ProjectTemplate
{
    public partial class Toggle : PropertyFrame<Boolean>
    {
        #region Overrided Methods

        public override void Initialize(Boolean property, Setting setting)
        {
            base.Initialize(property, setting);

            _trueText = property.TrueText;
            _falseText = property.FalseText;

            _state.onValueChanged.AddListener(ChangeState);

            ChangeStateText((bool)Value);
        }

        #endregion

        #region Private Methods

        private partial void ChangeState(bool value)
        {
            ChangeStateText(value); Value = value;
        }

        private partial void ChangeStateText(bool value)
            => _infoText.text = (_state.isOn = value) ? _trueText[Language] : _falseText[Language];

        #endregion
    }
}