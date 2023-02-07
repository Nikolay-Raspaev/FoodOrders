using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Enums;
using FoodOrdersDataModels.Models;
using System.Reflection;

namespace FoodOrdersListImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        public int SetOfDishesId { get; private set; }
        public string SetOfDishesName { get; private set; } = string.Empty;
        public int Count { get; private set; }
        public double Sum { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime? DateImplement { get; private set; }
       
        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                SetOfDishesId = model.SetOfDishesId,
                SetOfDishesName = model.SetOfDishesName,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }
        public void Update(OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            SetOfDishesId = model.SetOfDishesId;
            SetOfDishesName = model.SetOfDishesName;
            Count = model.Count;
            Sum = model.Sum;
            Status = model.Status;
            DateCreate = model.DateCreate;
            DateImplement = model.DateImplement;
        }
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            SetOfDishesId = SetOfDishesId,
            SetOfDishesName = SetOfDishesName,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
    }
}