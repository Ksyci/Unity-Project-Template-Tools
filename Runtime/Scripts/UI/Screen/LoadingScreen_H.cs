namespace ProjectTemplate
{
    /// <summary>
    /// Displays a loading <see cref="Screen"/> during <see cref="GameScene"/> transitions.
    /// </summary>
    public partial class LoadingScreen : Screen
    {
        #region Properties

        protected override Transition Transition => new Fade(_display, TRANSITION_DURATION);

        #endregion

        #region Methods

        /// <summary>
        /// Handles the logic to stop and hide the loading screen when the specified scene has finished loading.
        /// </summary>
        /// <param name="scene">The scene that has been loaded.</param>
        private partial void ManageStop(GameScene scene);

        #endregion
    }
}