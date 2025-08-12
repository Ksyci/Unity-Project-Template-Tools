using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="Menu"/> for managing user <see cref="Setting"/>, organizing them into categories and
    /// providing UI elements for editing individual settings.
    /// </summary>
    public partial class SettingsMenu : Menu
    {
        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private Button _returnButton;

        [SerializeField, ReadOnly]
        private ScrolledFrame _categoriesFrame;

        [SerializeField, ReadOnly]
        private ScrolledFrame _settingsFrame;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _title;

        [SerializeField, ReadOnly]
        private TextButton _textButtonPrefab;

        [SerializeField, ReadOnly]
        private Binder _binderPrefab;

        [SerializeField, ReadOnly]
        private Field _fieldPrefab;

        [SerializeField, ReadOnly]
        private Selector _selectorPrefab;

        [SerializeField, ReadOnly]
        private Slider _sliderPrefab;

        [SerializeField, ReadOnly]
        private Toggle _togglePrefab;

        #endregion

        #region Variables

        private Dictionary<Translator, List<UIElement>> _settings;

        #endregion

        #region Methods

        /// <summary>
        /// Creates UI buttons for each settings category and binds their behavior.
        /// </summary>
        private partial void CreateCategories();

        /// <summary>
        /// Changes the currently displayed category of settings and updates the UI accordingly.
        /// </summary>
        /// <param name="newCategory">The new category to display.</param>
        private partial void ChangeCategory(Translator newCategory);

        /// <summary>
        /// Creates a UI element for a specific setting based on its template and category.
        /// </summary>
        /// <param name="template">The template describing the setting UI.</param>
        /// <param name="setting">The actual setting data.</param>
        /// <param name="category">The category this setting belongs to.</param>
        private partial void CreateSetting(SettingTemplate template, Setting setting, Translator category);

        /// <summary>
        /// Creates all the settings UI elements for all categories.
        /// </summary>
        private partial void CreateSettings();

        /// <summary>
        /// Instantiates and initializes a UI element of the specified type for a setting.
        /// </summary>
        /// <typeparam name="TFrame">The type of the UI frame to instantiate.</typeparam>
        /// <typeparam name="TProperty">The type of the setting property.</typeparam>
        /// <param name="template">The setting template used for UI creation.</param>
        /// <param name="setting">The setting data instance.</param>
        /// <param name="category">The category to which the setting belongs.</param>
        private partial void InstantiateElement<TFrame, TProperty>(SettingTemplate template, Setting setting, Translator category)
            where TFrame : PropertyFrame<TProperty>
            where TProperty : Property;

        /// <summary>
        /// Find the prefab of the <see cref="PropertyFrame{TProperty}"/> with a corresponding <see cref="Property"/>.
        /// </summary>
        /// <typeparam name="TFrame">The type of the UI frame to instantiate.</typeparam>
        /// <typeparam name="TProperty">The type of the setting property.</typeparam>
        /// <returns>The prefab of the <see cref="PropertyFrame{TProperty}"/>.</returns>
        private partial TFrame FindFrame<TFrame, TProperty>()
            where TFrame : PropertyFrame<TProperty>
            where TProperty : Property;

        #endregion
    }
}