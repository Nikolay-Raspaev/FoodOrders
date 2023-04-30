using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Enums;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FoodOrdersDatabaseImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public int DishId { get; set; }
        [DataMember]
        [Required]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Required]
        public int Count { get; set; }
        [DataMember]
        [Required]
        public double Sum { get; set; }
        [DataMember]
        [Required]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Required]
        public DateTime DateCreate { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Client Client { get; set; }

        public Implementer? Implementer { get; private set; }
        [DataMember]
        public DateTime? DateImplement { get; set; }

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
                ClientId = model.ClientId,
                ImplementerId = model.ImplementerId,
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
            ImplementerId = model.ImplementerId;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            DishId = DishId,
            ClientId = ClientId,
            ImplementerId = ImplementerId,
            ClientFIO = Client.ClientFIO,
            ImplementerFIO = Implementer?.ImplementerFIO ?? string.Empty,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
            DishName = Dish.DishName
        };
    }
}