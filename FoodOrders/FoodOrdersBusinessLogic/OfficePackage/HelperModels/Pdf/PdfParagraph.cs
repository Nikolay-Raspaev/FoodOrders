using FoodOrdersBusinessLogic.OfficePackage.HelperEnums;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels.Pdf
{
    public class PdfParagraph
    {
        public string Text { get; set; } = string.Empty;

        public string Style { get; set; } = string.Empty;

        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}