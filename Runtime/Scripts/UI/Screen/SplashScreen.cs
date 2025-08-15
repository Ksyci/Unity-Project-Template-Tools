using System;
using System.Collections;
using UnityEngine;

namespace ProjectTemplate
{
    public partial class SplashScreen : Screen
    {
        #region Unity Methods

        private void Start() => Play();

        #endregion

        #region Overrided Methods

        protected override IEnumerator Execute()
        {
            yield return new WaitForSeconds(TRANSITION_DURATION + SPLASH_SCREEN_DURATION);

            Stop();

            yield return new WaitForSeconds(TRANSITION_DURATION);

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
                    yield break;
                }
            }
        }

        #endregion
    }
}