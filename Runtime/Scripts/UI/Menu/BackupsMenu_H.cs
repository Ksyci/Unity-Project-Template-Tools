using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    /// <summary>
    /// <see cref="Menu"/> managing backups with paginated grid display,
    /// allowing navigation between pages and customization of rows and columns.
    /// </summary>
    public partial class BackupsMenu : Menu
    {
        #region Constantes

        private const int MAX_ROW = 10;
        private const int MAX_COLUMN = 10;
        private const int MAX_PAGE = 25;

        private const string COLUMN_NAME = "Column";

        #endregion

        #region Serialized

        [Header(Format.REFERENCES_HEADER)]

        [SerializeField, ReadOnly]
        private TranslatedText _pageNumber;

        [SerializeField, ReadOnly]
        private Button _returnButton;

        [SerializeField, ReadOnly]
        private Button _previousPageButton;

        [SerializeField, ReadOnly]
        private Button _nextPageButton;

        [SerializeField, ReadOnly]
        private HorizontalLayoutGroup _grid;

        [SerializeField, ReadOnly]
        private BackupFrame _backupFramePrefab;

        [Header(Format.EDITABLES_HEADER)]

        [SerializeField]
        private int _spacing;

        [SerializeField, Range(1, MAX_ROW)]
        private int _rowCount = 1;

        [SerializeField, Range(1, MAX_COLUMN)]
        private int _columnCount = 1;

        #endregion

        #region Variables

        private int _pageIndex;

        private List<BackupFrame> _backupFrames;

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new column <see cref="GameObject"/> for the grid at the specified index.
        /// </summary>
        /// <param name="index">The index at which to create the column.</param>
        /// <returns>The created column <see cref="GameObject"/>.</returns>
        private partial GameObject CreateColumn(int index);

        /// <summary>
        /// Builds or refreshes the grid layout of <see cref="BackupFrame"/> based on
        /// the current row, column, and page settings.
        /// </summary>
        public partial void MakeGrid();

        #endregion
    }
}