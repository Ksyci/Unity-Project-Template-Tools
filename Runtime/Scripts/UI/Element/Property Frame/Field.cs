using TMPro;
using UnityEngine.UI;

namespace ProjectTemplate
{
    public partial class Field : PropertyFrame<String>
    {
        #region Overrided Methods

        public override void Initialize(String property, Setting setting)
        {
            base.Initialize(property, setting);

            TextMeshProUGUI placholder = _inputField.placeholder as TextMeshProUGUI;

            void ChangePlaceholder() => placholder.text = property.PlaceHolder[Language];
            LanguagesManager.Instance.BindAndApply(ChangePlaceholder);

            _format = property.FormatType;
            _maxCharacters = property.MaxCharacters;

            _inputField.onValueChanged.AddListener(ChangeText);

            Validate(Value.ToString());
        }

        #endregion

        #region Private Methods

        private partial void ChangeText(string value)
        {
            Validate(value);

            Value = value;
        }

        private partial void Validate(string value)
        {
            if (!Format.IsValid(value, _format))
            {
                value = Format.Clean(value, _format);
            }
            if (value.Length > _maxCharacters)
            {
                value = value[.._maxCharacters];
            }

            _inputField.text = value;
        }

        #endregion
    }
}