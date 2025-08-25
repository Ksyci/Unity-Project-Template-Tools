using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// Represents a single <see cref="Backup"/> entry <see cref="UIElement"/>, showing its details and providing
    /// buttons to save, load, or delete the <see cref="Backup"/>.
    /// </summary>
    public partial class BackupFrame : UIElement
    {
        #region Static

        public static readonly Color LightGrey = new(0.75f, 0.75f, 0.75f);

        #endregion

        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private Image _backgroundFrame;

        [SerializeField, ReadOnly]
        private Image _screenshot;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _nameText;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _dateTimeText;

        [SerializeField, ReadOnly]
        private TextMeshProUGUI _screenshotState;

        [SerializeField, ReadOnly]
        private Button _saveButton;

        [SerializeField, ReadOnly]
        private Button _loadButton;

        [SerializeField, ReadOnly]
        private Button _deleteButton;

        [Header(Format.EDITABLES_HEADER)]

        [SerializeField]
        private Translator _saveWarning;

        [SerializeField]
        private Translator _deleteWarning;

        #endregion

        #region Variables

        private int _associatedBackupIndex;

        #endregion

        private Backup AssociatedBackup => BackupsManager.Instance[_associatedBackupIndex];

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Saves the backup to the associated slot.
        /// </summary>
        private partial void Save();

        /// <summary>
        /// Loads the backup from the associated slot.
        /// </summary>
        private partial void Load();

        /// <summary>
        /// Deletes the backup from associated slot.
        /// </summary>
        private partial void Delete();

        #endregion
    }
}