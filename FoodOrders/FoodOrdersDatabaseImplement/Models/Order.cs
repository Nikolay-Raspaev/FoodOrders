using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Enums;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdersDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        [Required]
        public int DishId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [Required]
        public virtual Dish Dish { get; set; }

        [Required]
        public DateTime? DateImplement { get; set; }

        public int Id { get; set; }

        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                DishId = model.DishId,
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
            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            DishId = DishId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
    }
}