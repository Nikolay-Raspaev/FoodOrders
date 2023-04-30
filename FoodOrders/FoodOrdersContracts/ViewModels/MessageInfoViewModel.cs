using FoodOrdersContracts.Attributes;
using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    public class MessageInfoViewModel : IMessageInfoModel
    {
        [Column(visible: false)]
        public string MessageId { get; set; } = string.Empty;

        [Column(visible: false)]
        public int? ClientId { get; set; }

        [Column("Отправитель", gridViewAutoSize: GridViewAutoSize.DisplayedCells, isUseAutoSize: true)]
        public string SenderName { get; set; } = string.Empty;

        [Column("Дата письма", width: 100, format: "D")]
        public DateTime DateDelivery { get; set; }

        [Column("Заголовок", width: 150)]
        public string Subject { get; set; } = string.Empty;

        [Column("Текст", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Body { get; set; } = string.Empty;

        public int Id => throw new NotImplementedException();

        [DisplayName("Прочитано")]
        public bool HasRead { get; set; }

        [DisplayName("Ответ")]
        public string? Reply { get; set; }
    }
}