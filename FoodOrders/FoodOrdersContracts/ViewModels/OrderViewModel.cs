using FoodOrdersContracts.Attributes;
using FoodOrdersDataModels.Enums;
using FoodOrdersDataModels.Models;
using System.ComponentModel;
namespace FoodOrdersContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [Column("Номер", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public int Id { get; set; }

        [Column(visible: false)]
        public int DishId { get; set; }

        [Column("Набор", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public string DishName { get; set; } = string.Empty;

        [Column(visible: false)]
        public int ClientId { get; set; }

        [Column("Клиент", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ClientFIO { get; set; } = string.Empty;

        [Column("Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ImplementerFIO { get; set; } = string.Empty;

        [Column(visible: false)]
        public int? ImplementerId { get; set; }

        [Column("Количество", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public int Count { get; set; }

        [Column("Сумма", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true, format: "0.00")]
        public double Sum { get; set; }

        [Column("Статус", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

        [Column("Дата создания", width: 100, format: "D")]
        public DateTime DateCreate { get; set; } = DateTime.Now;

        [Column("Дата выполнения", width: 100, format: "D")]
        public DateTime? DateImplement { get; set; }
    }
}
