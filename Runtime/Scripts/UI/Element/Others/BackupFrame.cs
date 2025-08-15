using UnityEngine;

namespace ProjectTemplate
{
    public partial class BackupFrame : UIElement
    {
        #region Unity Methods

        private void Start()
        {
            _saveButton.onClick.AddListener(Save);
            _loadButton.onClick.AddListener(Load);
            _deleteButton.onClick.AddListener(Delete);
        }

        #endregion

        #region Public Methods

        public void UpdateDisplay(int index)
        {
            _associatedBackupIndex = index;
            _associatedBackup = BackupsManager.Instance[index];


            bool isActiveBackup = _associatedBackup == BackupsManager.Instance.ActiveBackup;
            bool isInGame = GameManager.Instance.CurrentState == EnumLibrary.StatesMapping[EnumLibrary.State.PAUSED];
            bool isNull = _associatedBackup == null;
            bool isOtherBackup = !isNull && !isActiveBackup;

            _saveButton.interactable = isInGame && !isOtherBackup;
            _loadButton.interactable = !isInGame && !isNull;
            _deleteButton.interactable = !isInGame && !isNull;

            _screenshot.sprite = BackupsManager.LoadScreenshot(_associatedBackup);
            _screenshot.color = _screenshot.sprite != null ? Color.white : default;
            _screenshotState.gameObject.SetActive(_screenshot.sprite == null);

            _nameText.text = !isNull ? _associatedBackup.Name : string.Empty;

            _dateTimeText.text = !isNull ? Format.ToDate(_associatedBackup.Time) : string.Empty;

            _backgroundFrame.color = isActiveBackup && isInGame ? LightGrey : Color.white;
        }

        #endregion

        #region Private Methods

        private partial void Save()
        {
            if (_associatedBackup != null)
            {
                BackupsManager.Instance.Save(_associatedBackup);
            }
            else
            {
                BackupsManager.Instance.Copy(_associatedBackupIndex);
            }
        }

        private partial void Load()
            => BackupsManager.Instance.Load(_associatedBackup);

        private partial void Delete()
        {
            string warning = _deleteWarning[LanguagesManager.Instance.ActiveLanguage];
            MonoLibrary.Confirm(action, warning);

            void action()
            {
                BackupsManager.Instance.Delete(_associatedBackup);

                BackupsManager.Instance.OnBackupChanged?.Invoke();
            }
        }

        #endregion
    }
}