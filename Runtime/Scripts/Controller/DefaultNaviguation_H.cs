using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// Handles default player navigation controls.
    /// </summary>
    public partial class DefaultNaviguation : Controller
    {
        #region Constantes

        private const float MAX_ANGLE = 360.0f;
        private const float MAX_PITCH_ANGLE = 80.0f;

        public const string PAUSE_EVENT_NAME = "Pause";
        public const string FORMWARD_EVENT_NAME = "Move Forward";
        public const string BACK_EVENT_NAME = "Move Back";
        public const string LEFT_EVENT_NAME = "Move Left";
        public const string RIGHT_EVENT_NAME = "Move Right";

        #endregion

        #region Enumerations

        /// <summary>
        /// Defines the possible movement or facing directions.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description><c>FORWARD</c> = Moves forward.</description></item>
        /// <item><description><c>BACK</c> = Moves backward.</description></item>
        /// <item><description><c>LEFT</c> = Moves to the left.</description></item>
        /// <item><description><c>RIGHT</c> = Moves to the right.</description></item>
        /// </list>
        /// </remarks>
        public enum Direction { FORWARD, BACK, LEFT, RIGHT }

        #endregion

        #region Serialized

        [SerializeField]
        private float _velocity;

        [SerializeField]
        private float _sensitivity;

        [SerializeField]
        private Transform _pitch;

        [SerializeField]
        private Transform _yaw;

        #endregion

        #region Variables

        private bool _isLocked;

        private Vector3 _direction;

        private DefaultNavigationData _data;

        #endregion

        #region Properties

        public float Velocity => _velocity;

        public float Sensitivity => _sensitivity;

        private Vector3 Forward => new(transform.forward.x, 0.0f, transform.forward.z);

        private Vector3 Right => new(transform.right.x, 0.0f, transform.right.z);

        #endregion

        #region Methods

        /// <summary>
        /// Toggles the lock state of the cursor and input control.
        /// </summary>
        public partial void ChangeLockState();

        /// <summary>
        /// Changes the current movement direction based on an input index mapped to a direction.
        /// </summary>
        /// <param name="index">Index corresponding to a direction (Forward, Back, Left, Right).</param>
        public partial void ChangeDirection(int index);

        /// <summary>
        /// Instantiate de data (position and rotation) of the object and link it with <see cref="Backup"/>.
        /// </summary>
        private partial void SetTransform();

        /// <summary>
        /// Moves the controlled object in the current direction with applied velocity.
        /// </summary>
        private partial void Move();

        /// <summary>
        /// Rotates the controlled object based on mouse input with sensitivity adjustment.
        /// </summary>
        private partial void Rotate();

        /// <summary>
        /// Clamps and adjusts the pitch rotation to prevent over-rotation.
        /// </summary>
        /// <param name="xPosition">Current pitch angle in degrees.</param>
        private partial void AdjustPitch(float xPosition);

        /// <summary>
        /// Sets the cursor lock state and visibility.
        /// </summary>
        /// <param name="isLocked">If true, locks the cursor and hides it; otherwise unlocks and shows it.</param>
        private partial void Lock(bool isLocked);

        /// <summary>
        /// Binds a setting-defined keycode to a KeyEvent and sets up its update callback.
        /// </summary>
        /// <param name="name">The name of the event to bind.</param>
        private partial void BindEvent(string name);

        #endregion
    }
}