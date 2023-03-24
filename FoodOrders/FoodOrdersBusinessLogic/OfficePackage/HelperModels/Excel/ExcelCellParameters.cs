using FoodOrdersBusinessLogic.OfficePackage.HelperEnums;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Excel
{
    public class ExcelCellParameters
    {
        public string ColumnName { get; set; } = string.Empty;

        public uint RowIndex { get; set; }

        public string Text { get; set; } = string.Empty;

        public string CellReference => $"{ColumnName}{RowIndex}";

        public ExcelStyleInfoType StyleInfo { get; set; }
    }
}