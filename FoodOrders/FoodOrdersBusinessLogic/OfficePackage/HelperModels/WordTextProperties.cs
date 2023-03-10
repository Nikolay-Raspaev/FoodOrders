using FoodOrdersBusinessLogic.OfficePackage.HelperEnums;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels
{
    public class WordTextProperties
    {
        public string Size { get; set; } = string.Empty;

        public bool Bold { get; set; }

        public WordJustificationType JustificationType { get; set; }
    }
}
