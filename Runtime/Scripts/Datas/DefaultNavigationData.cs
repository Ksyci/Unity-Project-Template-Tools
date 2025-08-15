using Newtonsoft.Json;
using System;
using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// Stores position and rotation data for navigation purposes,
    /// allowing serialization of transform information.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DefaultNavigationData : Backup.IData
    {
        #region Variable

        [JsonProperty]
        private float _xPosition;

        [JsonProperty]
        private float _yPosition;

        [JsonProperty]
        private float _zPosition;

        [JsonProperty]
        private float _pitch;

        [JsonProperty]
        private float _yaw;

        #endregion

        #region Properties

        [JsonIgnore]
        public Type Type => typeof(DefaultNavigationData);

        [JsonIgnore]
        public Vector3 Position => new(_xPosition, _yPosition, _zPosition);

        [JsonIgnore]
        public Quaternion Pitch => Quaternion.Euler(Vector3.right * _pitch);

        [JsonIgnore]
        public Quaternion Yaw => Quaternion.Euler(Vector3.up * _yaw);

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of <see cref="DefaultNavigationData"/>
        /// by copying the local position and rotation from the given <paramref name="transform"/>.
        /// </summary>
        /// <param name="transform">The Transform from which to copy position and rotation data.</param>
        [JsonConstructor]
        public DefaultNavigationData(Transform transform) 
            => Set(transform);

        /// <summary>
        /// Initializes a new instance of <see cref="DefaultNavigationData"/>
        /// by copying position and rotation data from another instance.
        /// </summary>
        /// <param name="data">The instance to copy data from.</param>
        public DefaultNavigationData(DefaultNavigationData data)
        {
            _xPosition = data._xPosition;
            _yPosition = data._yPosition;
            _zPosition = data._zPosition;

            _pitch = data._pitch;
            _yaw = data._yaw;
        }

        /// <summary>
        /// Set the position and the rotation of the data with a <see cref="Transform"/>.
        /// </summary>
        /// <param name="transform">The <see cref="Transform"/>from where to set the values.</param>
        public void Set(Transform transform)
        {
            if(transform != null)
            {
                _xPosition = transform.localPosition.x;
                _yPosition = transform.localPosition.y;
                _zPosition = transform.localPosition.z;

                _pitch = transform.localEulerAngles.x;
                _yaw = transform.localEulerAngles.y;
            }
        }

        /// <summary>
        /// Creates a deep copy of this DefaultNavigationData instance.
        /// </summary>
        /// <returns>A new instance of DefaultNavigationData with copied data.</returns>
        public object Clone() => new DefaultNavigationData(this);

        #endregion
    }
}