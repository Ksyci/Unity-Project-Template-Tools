namespace ProjectTemplate
{
    public partial class MainMenu : Menu
    {
        #region Unity Methods

        private void Start()
        {
            void load() => BackupsManager.Instance.Load(BackupsManager.Instance.ActiveBackup);
            void quit() => MonoLibrary.Confirm(MonoLibrary.Quit, _quitWarning[LanguagesManager.Instance.ActiveLanguage]);

            _startButton.onClick.AddListener(() => GoTo(nameof(StartMenu)));
            _backupsButton.onClick.AddListener(() => GoTo(nameof(BackupsMenu)));
            _settingsButton.onClick.AddListener(() => GoTo(nameof(SettingsMenu)));
            _continueButton.onClick.AddListener(load);
            _quitButton.onClick.AddListener(quit);
        }

        #endregion

        #region Overrided Methods

        protected override void UpdateDisplay()
        {
            int maxBackup = ProjectProperties.Get().BackupsConfiguration.MaxBackup;
            int backupCount = BackupsManager.Instance.BackupCount;
            bool isActiveBackupNull = BackupsManager.Instance.ActiveBackup == null;

            _startButton.interactable = backupCount < maxBackup;
            _continueButton.interactable = !isActiveBackupNull;
        }

        #endregion
    }
}