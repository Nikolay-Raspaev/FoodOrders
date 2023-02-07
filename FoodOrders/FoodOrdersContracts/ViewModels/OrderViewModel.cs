using FoodOrdersDataModels.Enums;
using FoodOrdersDataModels.Models;
using System.ComponentModel;
namespace FoodOrdersContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }

        public int SetOfDishesId { get; set; }

        [DisplayName("Изделие")]
        public string SetOfDishesName { get; set; } = string.Empty;

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public double Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
       
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
