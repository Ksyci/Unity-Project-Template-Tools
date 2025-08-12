using System.Collections;
using UnityEngine;

namespace ProjectTemplate
{
    public partial class LoadingScreen : Screen
    {
        #region Unity Methods

        private void Start()
        {
            Initializer.OnSceneChanged.AddListener(ManageStop);
            Play();
        }

        private void OnDestroy()
            => Initializer.OnSceneChanged.RemoveListener(ManageStop);

        #endregion

        #region Overrided Methods

        protected override IEnumerator Execute()
        {
            yield return new WaitForSeconds(TRANSITION_DURATION);
        }

        #endregion

        #region Private Methods

        private partial void ManageStop(GameScene scene)
        {
            if (scene != ProjectProperties.Get().LoadingScene)
            {
                Stop();
            }
        }

        #endregion
    }
}