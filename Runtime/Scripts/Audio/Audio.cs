using System.Linq;
using UnityEngine;

namespace ProjectTemplate
{
    public partial class Audio : MonoBehaviour
    {
        #region Unity Methods

        private void Start()
        {
            _category = _categoriesMapping[_type];

            _source.volume = AudioManager.Instance[_category].Volume;
            _source.clip = GetVoiceClip();

            AudioManager.Instance.AddSource(_source, _category);
        }

        private void OnDisable()
            => AudioManager.Instance.RemoveSource(_source, _category);

        #endregion

        #region Private Methods

        private partial AudioClip GetVoiceClip()
        {
            if (_type != Category.VOICE)
            {
                return _clips[0];
            }
            else
            {
                string language = LanguagesManager.Instance.ActiveLanguage;
                int index = ProjectProperties.Get().Languages.ToList().IndexOf(language);
                return (index >= 0 && index < _clips.Count) ? _clips[index] : null;
            }
        }

        #endregion
    }
}