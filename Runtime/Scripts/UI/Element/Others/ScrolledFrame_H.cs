using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// UI container with a scrollable area and scrollbar, managing child elements
    /// that can be dynamically added and scrolled.
    /// </summary>
    public partial class ScrolledFrame : UIElement
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField]
        private RectTransform _scrollArea;

        [Header(Format.EDITABLES_HEADER)]

        [SerializeField]
        private Scrollbar _scrollBar;

        #endregion

        #region Variables

        private bool _isValidScroll;

        private float _scrollDistance;

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new UI element of type <typeparamref name="T"/> to the scrollable content area.
        /// </summary>
        /// <typeparam name="T">The type of the UI element to add.</typeparam>
        /// <param name="obj">The <see cref="Object"/> instance to add.</param>
        /// <returns>The added <see cref="Object"/>.</returns>
        public partial T Add<T>(T obj) where T : Object;

        /// <summary>
        /// Adjusts the scroll position of the scrollable content based on the given value.
        /// </summary>
        /// <param name="value">The new scroll value (usually between 0 and 1).</param>
        private partial void Scroll(float value);

        #endregion
    }
}