using UnityEngine.Events;

namespace ProjectTemplate
{
    public partial class TextButton : UIElement
    {
        #region Public Methods

        public partial void Bind(UnityAction action) => _button.onClick.AddListener(action);

        #endregion
    }
}