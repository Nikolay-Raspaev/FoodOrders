using FoodOrdersBusinessLogic.OfficePackage.HelperEnums;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Word
{
    //информация по свойствам текста
    public class WordTextProperties
    {
        public string Size { get; set; } = string.Empty;

        public bool Bold { get; set; }

        //выравнивание текста
        public WordJustificationType JustificationType { get; set; }
    }
}
