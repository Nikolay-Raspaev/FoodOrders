using FoodOrdersContracts.ViewModels;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<ReportDishComponentViewModel> DishComponents { get; set; } = new();
    }
}