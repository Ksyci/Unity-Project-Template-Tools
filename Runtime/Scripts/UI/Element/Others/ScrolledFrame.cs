using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    public partial class ScrolledFrame : UIElement
    {
        #region Unity Methods
        private void Start()
            => _scrollBar.onValueChanged.AddListener(Scroll);

        private void Update()
        {
            float scrollAreaHeight = _scrollArea.GetComponent<RectTransform>().rect.height;

            float scrolledFrameHeight = _transform.rect.height;

            _scrollDistance = scrollAreaHeight - scrolledFrameHeight;

            _scrollBar.interactable = _scrollDistance > 0;

            if (_isValidScroll != _scrollBar.interactable)
            {
                _isValidScroll = _scrollBar.interactable;

                _scrollArea.anchoredPosition = Vector2.zero;
            }
        }

        #endregion

        #region Public Methods

        public partial T Add<T>(T obj) where T : Object
            => Instantiate(obj, _scrollArea);

        #endregion

        #region Private Methods

        private partial void Scroll(float value)
            => _scrollArea.anchoredPosition = _scrollDistance * value * Vector2.up;

        #endregion
    }
}