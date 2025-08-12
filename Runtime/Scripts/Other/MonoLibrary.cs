using UnityEngine;
using UnityEngine.Events;

namespace ProjectTemplate
{
    /// <summary>
    /// Library that can be use as a <see cref="MonoBehaviour"/> for <see cref="UnityEvent"/>
    /// </summary>
    public class MonoLibrary : MonoBehaviour
    {
        #region Methods

        /// <summary>
        /// Toggles between paused and in-game states, updating the UI accordingly.
        /// </summary>
        public void ChangePauseState()
        {
            if (GameManager.Instance.CurrentState == EnumLib.State.PAUSED)
            {
                GameScene currentScene = ScenesManager.Instance.CurrentScene;

                string uiName = currentScene.DefaultUi != null ? currentScene.DefaultUi.GetType().Name : null;

                UIsManager.Instance.Replace(uiName);

                GameManager.Instance.ChangeGameState(EnumLib.State.IN_GAME);
            }
            else
            {
                UIsManager.Instance.Add(nameof(PauseMenu), false);

                GameManager.Instance.ChangeGameState(EnumLib.State.PAUSED);
            }
        }

        /// <summary>
        /// Quit the game.
        /// </summary>
        public static void Quit()
        {
            #if UNITY_EDITOR

            #pragma warning disable IDE0022

            UnityEditor.EditorApplication.isPlaying = false;

            #pragma warning restore IDE0022

            #else

            Application.Quit();

            #endif
        }

        /// <summary>
        /// Pause or Depause the Autosave <see cref="Coroutine"/>.
        /// </summary>
        /// <param name="isPaused">True: the autosave timer is paused; False: it resumes</param>
        public static void PauseAutosave(bool isPaused) => BackupsManager.Instance.IsAutosaveTimerPaused = isPaused;

        /// <summary>
        /// Start the Autosave <see cref="Coroutine"/>.
        /// </summary>
        public static void StartAutosave() => BackupsManager.Instance.StartAutosave();

        /// <summary>
        /// Stop the Autosave <see cref="Coroutine"/>.
        /// </summary>
        public static void StopAutosave() => BackupsManager.Instance.StopAutosave();

        /// <summary>
        /// Displays a confirmation prompt before executing a given action.
        /// </summary>
        /// <param name="action">The action to execute if confirmed.</param>
        /// <param name="warning">The warning message to display in the confirmation prompt.</param>
        public static void Confirm(UnityAction action, string warning) 
            => ConfirmMenu.OnConfirmRequested?.Invoke(action, warning);

        #endregion
    }
}