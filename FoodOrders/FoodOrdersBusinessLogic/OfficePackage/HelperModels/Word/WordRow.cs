namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Word
{
    public class WordRow
    {
        public List<(string, WordTextProperties)> Rows { get; set; } = new();
    }
}
