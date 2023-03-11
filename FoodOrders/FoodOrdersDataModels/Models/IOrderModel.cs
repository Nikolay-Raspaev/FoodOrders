using FoodOrdersDataModels.Enums;

namespace FoodOrdersDataModels.Models
{
    public interface IOrderModel : IId
    {
        int DishId { get; }
        int Count { get; }
        double Sum { get; }
        OrderStatus Status { get; }
        DateTime DateCreate { get; }
        //через "?" обозначается что поле может быть null
        DateTime? DateImplement { get; }
    }
}
