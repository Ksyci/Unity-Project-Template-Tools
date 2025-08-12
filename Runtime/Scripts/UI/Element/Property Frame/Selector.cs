using System;
using System.Linq;
using UnityEditor;

namespace ProjectTemplate
{
    public partial class Selector : PropertyFrame<Enum>
    {
        #region Overrided Methods

        public override void Initialize(Enum property, Setting setting)
        {
            base.Initialize(property, setting);

            _enum = property.Types.ToArray();

            _backButton.interactable = _enum.Length > 1;
            _forwardButton.interactable = _enum.Length > 1;

            _backButton.onClick.AddListener(LastState);
            _forwardButton.onClick.AddListener(NextState);

            ChangeText(Convert.ToInt32(Value));
        }

        #endregion

        #region Private Methods

        private partial void NextState()
            => ChangeState(Convert.ToInt32(Value) + 1);

        private partial void LastState()
            => ChangeState(Convert.ToInt32(Value) - 1);

        private partial void ChangeState(int index)
        {
            Value = _enum.Length > 1 ? FindState(index) : 0;
            ChangeText(index);
        }

        private partial void ChangeText(int index)
            => _state.text = _enum.Length != 0 ? _enum[FindState(index)][Language] : string.Empty;

        private partial int FindState(int index)
            => (index + _enum.Length) % _enum.Length;

        #endregion
    }
}