namespace ProjectTemplate
{
    /// <summary>
    /// Displays an initial splash <see cref="Screen"/> for a fixed duration before transitioning
    /// to the main menu <see cref="GameScene"/>.
    /// </summary>
    public partial class SplashScreen : Screen
    {
        #region Constantes

        private const float SPLASH_SCREEN_DURATION = 2.0f;

        #endregion

        #region Properties

        protected override Transition Transition => new Fade(_display, TRANSITION_DURATION);

        #endregion
    }
}