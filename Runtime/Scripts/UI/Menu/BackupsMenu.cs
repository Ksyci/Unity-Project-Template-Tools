using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTemplate
{
    public partial class BackupsMenu : Menu
    {
        #region Unity Methods

        private void Start()
        {
            void GoToPeviousPage()
            {
                --_pageIndex;
                UpdateDisplay();
            }

            void GoToNextPage()
            {
                ++_pageIndex;
                UpdateDisplay();
            }

            _returnButton.onClick.AddListener(Return);
            _previousPageButton.onClick.AddListener(GoToPeviousPage);
            _nextPageButton.onClick.AddListener(GoToNextPage);

            BackupsManager.Instance.OnBackupChanged.AddListener(UpdateDisplay);

            MakeGrid();
        }

        #endregion

        #region Overrided Methods

        protected override void UpdateDisplay()
        {
            _previousPageButton.interactable = _pageIndex > 0;
            _nextPageButton.interactable = _pageIndex < MAX_PAGE - 1;

            _pageNumber.AddText(' ' + (_pageIndex + 1).ToString());

            int backupPerPage = _rowCount * _columnCount;

            for (int i = 0; i < _backupFrames.Count; i++)
            {
                int index = (_pageIndex * backupPerPage) + i;
                _backupFrames[i].UpdateDisplay(index);
            }
        }

        #endregion

        #region Public Methods

        public partial void MakeGrid()
        {
            for (int i = _grid.transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(_grid.transform.GetChild(i).gameObject);
            }

            _grid.spacing = _spacing;

            _backupFrames = new();

            for (int i = 0; i < _columnCount; i++)
            {
                GameObject column = CreateColumn(i);

                for (int j = 0; j < _rowCount; j++)
                {
                    BackupFrame frame = Instantiate(_backupFramePrefab, column.transform);
                    frame.gameObject.name = Format.Polish(nameof(BackupFrame)) + ' ' + j;
                    _backupFrames.Add(frame);
                }
            }
        }

        #endregion

        #region Private Methods

        private partial GameObject CreateColumn(int index)
        {
            GameObject column = new(COLUMN_NAME + ' ' + index);
            column.transform.SetParent(_grid.transform, false);

            VerticalLayoutGroup layout = column.AddComponent<VerticalLayoutGroup>();
            layout.spacing = _spacing;

            layout.childForceExpandWidth = true;
            layout.childForceExpandHeight = true;

            layout.childControlHeight = true;
            layout.childControlWidth = true;

            return column;
        }

        #endregion
    }
}