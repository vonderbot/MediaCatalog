using System.Collections;
using System.Globalization;

namespace MediaCatalog.UI.WinForms
{
    public class FileListViewItemComparer : IComparer
    {
        private int _columnIndex;
        private SortOrder _sortOrder;

        public FileListViewItemComparer(int columnIndex, SortOrder sortOrder)
        {
            _columnIndex = columnIndex;
            _sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            var itemX = x as ListViewItem;
            var itemY = y as ListViewItem;

            if (itemX == null || itemY == null)
                return 0;

            string valueX = itemX.SubItems[_columnIndex].Text;
            string valueY = itemY.SubItems[_columnIndex].Text;

            int result;

            if (_columnIndex == 2) // Дата создания
            {
                // Попытка преобразовать строки обратно в DateTime
                if (DateTime.TryParseExact(valueX, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                                           DateTimeStyles.None, out DateTime dateX) &&
                    DateTime.TryParseExact(valueY, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                                           DateTimeStyles.None, out DateTime dateY))
                {
                    result = DateTime.Compare(dateX, dateY);
                }
                else
                {
                    // Если не удалось преобразовать, сортируем как строки
                    result = string.Compare(valueX, valueY, StringComparison.OrdinalIgnoreCase);
                }
            }
            else
            {
                // Сортировка по имени и расширению (как строки)
                result = string.Compare(valueX, valueY, StringComparison.OrdinalIgnoreCase);
            }

            // Возвращаем результат с учётом порядка сортировки
            return _sortOrder == SortOrder.Descending ? -result : result;
        }
    }
}