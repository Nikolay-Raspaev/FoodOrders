using FoodOrdersContracts.ViewModels;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Word
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<DishViewModel> Dishes { get; set; } = new();
    }
}