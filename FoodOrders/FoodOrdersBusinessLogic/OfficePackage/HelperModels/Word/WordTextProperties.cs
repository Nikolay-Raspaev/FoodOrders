using FoodOrdersBusinessLogic.OfficePackage.HelperEnums;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Word
{

    /// <summary>
    /// Информация по свойствам текста
    /// </summary>
    /// <returns></returns>
    public class WordTextProperties
    {
        public string Size { get; set; } = string.Empty;

        public bool Bold { get; set; }

        //выравнивание текста
        public WordJustificationType JustificationType { get; set; }
    }
}
