using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="PropertyFrame{T}"/> that allows to display a <see cref="Float"/>.
    /// </summary>
    public partial class Slider : PropertyFrame<Float>
    {
        #region Constantes

        private const float ROUNDING_VALUE = 100.0f;

        #endregion

        #region Serialized

        [SerializeField, ReadOnly]
        private Scrollbar _gauge;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _value;

        #endregion

        #region Variables

        private bool _isInteger;

        private float _min;

        private float _max;

        #endregion

        #region Methods

        /// <summary>
        /// Updates the slider position and the displayed value based on the given float input.
        /// </summary>
        /// <param name="value">The new value to set for the slider.</param>
        private partial void Slide(float value);

        /// <summary>
        /// Rounds the given value according to the configured rounding precision.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The rounded float value.</returns>
        private partial float Round(float value);

        #endregion
    }
}