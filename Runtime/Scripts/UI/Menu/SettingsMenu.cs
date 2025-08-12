using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTemplate
{
    public partial class SettingsMenu : Menu
    {
        #region Unity Methods

        private void Start()
        {
            _settings = new();
            _returnButton.onClick.AddListener(Return);

            CreateCategories();
            CreateSettings();

            ChangeCategory(_settings.Keys.FirstOrDefault());
        }

        #endregion

        #region Private Methods

        private partial void CreateCategories()
        {
            Translator[] categories = ProjectProperties.Get().SettingSections.Select(s => s.Category).ToArray();

            foreach (Translator category in categories)
            {
                TextButton button = _categoriesFrame.Add(_textButtonPrefab);

                void ChangeTexts()
                {
                    string newText = category[LanguagesManager.Instance.ActiveLanguage];

                    _title.text = _title.text == button.Text ? newText : _title.text;
                    button.Text = newText;
                }

                LanguagesManager.Instance.BindAndApply(ChangeTexts);

                button.Bind(() => ChangeCategory(category));

                _settings.Add(category, new());
            }
        }

        private partial void CreateSettings()
        {
            foreach (SettingSection section in ProjectProperties.Get().SettingSections)
            {
                Translator category = section.Category;
                List<Setting> settingsInCategory = SettingsManager.Instance.Settings[category.Default];

                foreach (SettingTemplate template in section.SettingTemplates)
                {
                    Setting setting = settingsInCategory.First(s => s.Name == template.Property.Name.Default);

                    CreateSetting(template, setting, category);
                }
            }
        }

        private partial void ChangeCategory(Translator newCategory)
        {
            try
            {
                List<UIElement> newElements = _settings[newCategory];

                foreach (var category in _settings)
                {
                    foreach (UIElement element in category.Value)
                    {
                        element.gameObject.SetActive(false);
                    }
                }

                foreach (UIElement element in newElements)
                {
                    element.gameObject.SetActive(true);
                }

                _title.text = newCategory[LanguagesManager.Instance.ActiveLanguage];
            }
            catch (KeyNotFoundException)
            {
                try
                {
                    throw new Error.InvalidCategoryException(newCategory.Default);
                }
                catch (Exception e)
                {
                    Error.Warn(e);
                }
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }

        private partial void CreateSetting(SettingTemplate template, Setting setting, Translator category)
        {
            switch (template.Type.Type)
            {
                case Type t when t == typeof(Boolean):

                    InstantiateElement<Toggle, Boolean>(template, setting, category); break;

                case Type t when t == typeof(Enum):

                    InstantiateElement<Selector, Enum>(template, setting, category); break;

                case Type t when t == typeof(Float):

                    InstantiateElement<Slider, Float>(template, setting, category); break;

                case Type t when t == typeof(Key):

                    InstantiateElement<Binder, Key>(template, setting, category); break;

                case Type t when t == typeof(String):

                    InstantiateElement<Field, String>(template, setting, category); break;
            }
        }

        private partial void InstantiateElement<TFrame, TProperty>(SettingTemplate template, Setting setting, Translator category)
            where TFrame : PropertyFrame<TProperty>
            where TProperty : Property
        {
            TFrame prefab = FindFrame<TFrame, TProperty>();

            TFrame element = _settingsFrame.Add(prefab);

            TProperty property = (TProperty)template.Property;

            element.Initialize(property, setting);

            _settings[category].Add(element);
        }

        private partial TFrame FindFrame<TFrame, TProperty>()
            where TFrame : PropertyFrame<TProperty>
            where TProperty : Property
            => typeof(TProperty) switch
            {
                var t when t == typeof(Key) => _binderPrefab as TFrame,
                var t when t == typeof(String) => _fieldPrefab as TFrame,
                var t when t == typeof(Enum) => _selectorPrefab as TFrame,
                var t when t == typeof(Float) => _sliderPrefab as TFrame,
                var t when t == typeof(Boolean) => _togglePrefab as TFrame,

                _ => null
            };

        #endregion
    }
}