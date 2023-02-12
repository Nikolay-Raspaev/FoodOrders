using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Enums;
using FoodOrdersDataModels.Models;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace FoodOrdersFileImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        public int DishId { get; private set; }
        public int Count { get; private set; }
        public double Sum { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime? DateImplement { get; private set; }

        public static Order? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            var order = new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                DishId = Convert.ToInt32(element.Element("DishId")!.Value),
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                DateCreate = DateTime.ParseExact(element.Element("DateCreate")!.Value, "G", null),
            };
            DateTime.TryParse(element.Element("DateImplement")!.Value, out DateTime dateImpl);
            order.DateImplement = dateImpl;

            if (!Enum.TryParse(element.Element("Status")!.Value, out OrderStatus status))
            {
                return null;
            }
            order.Status = status;
            return order;
        }

        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order
            {
                Id = model.Id,
                DishId = model.DishId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
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

        public XElement GetXElement => new(
          "Order",
           new XAttribute("Id", Id),
           new XElement("DishId", DishId.ToString()),
           new XElement("Count", Count.ToString()),
           new XElement("Sum", Sum.ToString()),
           new XElement("Status", Status.ToString()),
           new XElement("DateCreate", DateCreate.ToString()),
           new XElement("DateImplement", DateImplement.ToString())
      );
    }
}
