using Newtonsoft.Json;
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

        [JsonIgnore]
        private Transform _transform;

        #endregion

        #region Properties

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
        {
            _transform = transform;
            Generate();
        }

        /// <summary>
        /// Creates a deep copy of this DefaultNavigationData instance.
        /// </summary>
        /// <returns>A new instance of DefaultNavigationData with copied data.</returns>
        public object Clone()
        {
            DefaultNavigationData data = new(_transform)
            {
                _xPosition = _xPosition,
                _yPosition = _yPosition,
                _zPosition = _zPosition,

                _pitch = _pitch,
                _yaw = _yaw
            };

            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Generate()
        {
            if (_transform != null)
            {
                _xPosition = _transform.localPosition.x;
                _yPosition = _transform.localPosition.y;
                _zPosition = _transform.localPosition.z;

                _pitch = _transform.localEulerAngles.x;
                _yaw = _transform.localEulerAngles.y;
            }
        }

        #endregion
    }
}