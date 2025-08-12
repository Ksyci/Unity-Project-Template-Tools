using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace ProjectTemplate
{
    public partial class Binder : PropertyFrame<Key>
    {
        #region Overrided Methods

        public override void Initialize(Key property, Setting setting)
        {
            base.Initialize(property, setting);

            void changeKeyRoutine() => StartCoroutine(WaitForKeyInput());

            _validKeys = property.ValidKeys.ToArray();

            _keyButton.Bind(changeKeyRoutine);

            ChangeText((KeyCode)Convert.ToInt32(Value));
        }

        #endregion

        #region Private Methods

        private partial IEnumerator WaitForKeyInput()
        {
            Cursor.lockState = CursorLockMode.Locked;

            bool isKeychanged = _validKeys.Length == 0;

            while (!isKeychanged)
            {
                yield return new WaitUntil(() => Input.anyKeyDown);

                ChangeKey(ref isKeychanged);
            }

            Cursor.lockState = CursorLockMode.None;
        }

        private partial void ChangeKey(ref bool isKeychanged)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    if (isKeychanged = key == KeyCode.Delete)
                    {
                        ChangeText(default); break;
                    }
                    else if (isKeychanged = key == KeyCode.Escape)
                    {
                        break;
                    }
                    else if (isKeychanged = _validKeys.Contains(key))
                    {
                        ChangeText(key); break;
                    }
                }
            }
        }

        private partial void ChangeText(KeyCode key)
        {
            Value = _validKeys.Contains(key) ? (int)key : KeyCode.None;

            string text = (KeyCode)Value != KeyCode.None ? ((KeyCode)Value).ToString() : string.Empty;

            _keyButton.Text = '[' + text + ']';
        }

        #endregion
    }
}