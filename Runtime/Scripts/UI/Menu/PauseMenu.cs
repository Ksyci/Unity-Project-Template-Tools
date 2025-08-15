using System;

namespace ProjectTemplate
{
    public partial class PauseMenu : Menu
    {
        #region Unity Methods

        private void Start()
        {
            _backupsButton.onClick.AddListener(() => GoTo(nameof(BackupsMenu)));
            _settingsButton.onClick.AddListener(() => GoTo(nameof(SettingsMenu)));
            _mainMenuButton.onClick.AddListener(() => MonoLibrary.Confirm(Quit, QuitWarning));
        }

        #endregion

        #region Private Methods

        private partial void Quit()
        {
            try
            {
                GameScene scene = EnumLibrary.ScenesMapping[EnumLibrary.Scene.MAIN_MENU];

                ScenesManager.Instance.LoadScene(scene.Name);
            }
            catch (ArgumentOutOfRangeException)
            {
                try
                {
                    throw new Error.SceneNotFoundException(EnumLibrary.Scene.MAIN_MENU.ToString());
                }
                catch (Exception e)
                {
                    Error.Warn(e);
                }
            }
        }

        #endregion
    }
}