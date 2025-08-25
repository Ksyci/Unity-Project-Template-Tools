using System;
using UnityEngine;

namespace ProjectTemplate
{
    public partial class DefaultNaviguation : Controller
    {
        #region Unity Methods

        private void Start()
        {
            Lock(true);

            SetTransform();

            BindEvent(FORMWARD_EVENT_NAME);
            BindEvent(BACK_EVENT_NAME);
            BindEvent(LEFT_EVENT_NAME);
            BindEvent(RIGHT_EVENT_NAME);
        }

        private void OnDestroy() => Lock(false);

        protected override void Update()
        {
            base.Update();

            if (_isLocked)
            {
                Move();
                Rotate();
                _data.Set(transform);
            }
        }

        #endregion

        #region Public Methods

        public partial void ChangeLockState() => Lock(!_isLocked);

        public partial void ChangeDirection(int index)
        {
            if (_isLocked)
            {
                Direction direction = (Direction)index;

                switch (direction)
                {
                    case Direction.FORWARD:
                        _direction += Forward;
                        break;
                    case Direction.BACK:
                        _direction -= Forward;
                        break;
                    case Direction.LEFT:
                        _direction -= Right;
                        break;
                    case Direction.RIGHT:
                        _direction += Right;
                        break;
                }
            }
        }

        #endregion

        #region Private Methods

        private partial void SetTransform()
        {
            if (BackupsManager.Instance.ActiveBackup.TryGetData(out _data))
            {
                transform.localPosition = _data.Position;
                _pitch.localRotation = _data.Pitch;
                _yaw.localRotation = _data.Yaw;
            }
            else
            {
                BackupsManager.Instance.ActiveBackup.AddData(_data = new(transform));
            }
        }

        private partial void Move()
        {
            if (_direction != Vector3.zero)
            {
                _direction.Normalize();
                transform.localPosition += _velocity * Time.deltaTime * _direction;
            }

            _direction = Vector3.zero;
        }

        private partial void Rotate()
        {
            float dx = Input.GetAxis("Mouse X") * _sensitivity;
            float dy = Input.GetAxis("Mouse Y") * _sensitivity;

            _pitch.Rotate(Vector3.left * dy);
            _yaw.Rotate(Vector3.up * dx);

            float x = _pitch.localEulerAngles.x;
            float y = _yaw.localEulerAngles.y;

            AdjustPitch(x);

            transform.localEulerAngles = new Vector3(x, y, 0);
        }

        private partial void AdjustPitch(float xPosition)
        {
            if (xPosition > MAX_ANGLE / 2f) xPosition -= MAX_ANGLE;

            xPosition = Mathf.Clamp(xPosition, -MAX_PITCH_ANGLE, MAX_PITCH_ANGLE);

            _pitch.localEulerAngles = new Vector3(xPosition, 0f, 0f);
        }

        private partial void Lock(bool isLocked)
        {
            Cursor.lockState = !isLocked ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = !isLocked;
            _isLocked = isLocked;
        }

        private partial void BindEvent(string name)
        {
            Setting setting = SettingsManager.Instance[name];
            KeyEvent keyEvent = _eventsMapping[name];
            void move() => keyEvent.Key = (KeyCode)Convert.ToInt32(setting?.Value);
            setting?.BindAndExecute(move);
        }

        #endregion
    }
}