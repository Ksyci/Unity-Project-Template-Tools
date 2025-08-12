using System.Collections.Generic;
using UnityEngine;

namespace ProjectTemplate
{
    /// <summary>
    /// Represents an <see cref="AudioSource"/> that can be linked with the <see cref="AudioManager"/>.
    /// </summary>
    public partial class Audio : MonoBehaviour
    {
        #region Enumerations

        public enum Category { MUSIC, SOUND, VOICE };

        #endregion

        #region Static

        private static readonly Dictionary<Category, string> _categoriesMapping = new()
        {
            { Category.MUSIC, AudioManager.MUSIC_SETTING_NAME },
            { Category.SOUND, AudioManager.SOUNDS_SETTING_NAME },
            { Category.VOICE, AudioManager.VOICES_SETTING_NAME },
        };

        #endregion

        #region Serialized

        [SerializeField]
        private Category _type;

        [SerializeField]
        private AudioSource _source;

        [SerializeReference]
        private List<AudioClip> _clips;

        #endregion

        #region Variables

        private string _category;

        #endregion

        #region Properties

        public Category Type => _type;

        public AudioSource Source => _source;

        public IReadOnlyList<AudioClip> Clips => _clips;

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves the <see cref="AudioClip"/> that needs to be link to the <see cref="AudioSource"/>.
        /// </summary>
        /// <returns>The localized <see cref="AudioClip"/> or null if unavailable.</returns>
        private partial AudioClip GetVoiceClip();

        #endregion
    }
}