using System;
using System.Numerics;
using UnityEngine;

namespace ProjectTemplate
{
    public partial class Slider : PropertyFrame<Float>
    {
        #region Overrided Methods

        public override void Initialize(Float property, Setting setting)
        {
            base.Initialize(property, setting);

            _min = property.Min;
            _max = property.Max;

            _isInteger = property.IsInteger;

            float value = Mathf.Clamp(Convert.ToSingle(Value), _min, _max);
            value = Mathf.InverseLerp(_min, _max, value);

            _gauge.value = value;
            _gauge.onValueChanged.AddListener(Slide);

            Slide(value);
        }

        #endregion

        #region Private Methods

        private partial void Slide(float value)
        {
            value = Mathf.Lerp(_min, _max, value);
            value = Round(value);

            Value = value;

            bool isPercentage = _min == 0.0f && _max == 100.0f;

            string text = value.ToString();
            text = isPercentage ? text + '%' : text;
            _value.text = text;
        }

        private partial float Round(float value)
            => _isInteger ? Mathf.Round(value) : Mathf.Round(value * ROUNDING_VALUE) / ROUNDING_VALUE;

        #endregion
    }
}