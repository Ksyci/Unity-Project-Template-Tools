using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectTemplate
{
    public partial class ConfirmMenu : Menu
    {
        #region Unity Methods

        private void Start()
        {
            void confirmation(UnityAction action, string warning)
                => StartCoroutine(ThrowConfirmation(action, warning));

            OnConfirmRequested = new();
            OnConfirmRequested.AddListener(confirmation);

            _yesButton.onClick.AddListener(() => Confirm(true));
            _noButton.onClick.AddListener(() => Confirm(false));
        }

        private void OnDisable()
            => OnConfirmRequested?.RemoveAllListeners();

        #endregion

        #region Private Methods

        private partial IEnumerator ThrowConfirmation(UnityAction action, string warning)
        {
            UIsManager.Instance.Add(nameof(ConfirmMenu), true);

            _isConfirmed = false;

            _warningText.text = warning;

            yield return new WaitUntil(() => _isConfirmed);

            UIsManager.Instance.Remove(true);

            if (_isValid)
            {
                action();
            }
        }

        private partial void Confirm(bool isValid)
        {
            _isValid = isValid;
            _isConfirmed = true;
        }

        #endregion
    }
}