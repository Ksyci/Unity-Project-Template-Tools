namespace ProjectTemplate
{
    public partial class StartMenu : Menu
    {
        #region Unity Methods

        private void Start()
        {
            _returnButton.onClick.AddListener(Return);
            _startButton.onClick.AddListener(StartGame);

            _nameSetting = new(string.Empty);

            _nameField.Initialize(_nameProperty, _nameSetting);
        }

        #endregion

        #region Private Methods

        private partial void StartGame()
        {
            GameScene firstScene = ProjectProperties.Get().FirstScene;

            string name = _nameSetting.Value.ToString();

            BackupsManager.Instance.MakeNew(name);

            ScenesManager.Instance.LoadScene(firstScene.Name);
        }

        #endregion
    }
}