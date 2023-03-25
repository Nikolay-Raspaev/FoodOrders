namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Word
{
    public class WordParagraph
    {
        // текст, который входит в параграф
        public List<(string, WordTextProperties)> Texts { get; set; } = new();

        // свойства по умолчанию
        public WordTextProperties? TextProperties { get; set; }
    }
}