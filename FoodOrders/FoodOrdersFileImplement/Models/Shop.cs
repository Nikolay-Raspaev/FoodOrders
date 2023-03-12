using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FoodOrdersFileImplement.Models
{
    public class Shop : IShopModel
    {
        public string ShopName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public DateTime DateOfOpening { get; private set; } = DateTime.Now;
        public int Capacity { get; private set; } = 0;
        public int Id { get; private set; }
        public Dictionary<int, int> Dishes { get; private set; } = new();
        public Dictionary<int, (IDishModel, int)>? _shopDishes = null;
        public Dictionary<int, (IDishModel, int)> ShopDishes
        {
            get
            {
                if (_shopDishes == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _shopDishes = Dishes.ToDictionary(x => x.Key, y =>
                    ((source.Dishes.FirstOrDefault(z => z.Id == y.Key) as IDishModel)!, y.Value));
                }
                return _shopDishes;
            }
        }
        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOfOpening = model.DateOfOpening,
                Dishes = model.ShopDishes.ToDictionary(x => x.Key, x => x.Value.Item2),
                Capacity = model.Capacity
            };
        }
        public static Shop? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Address = element.Element("Address")!.Value,
                DateOfOpening = Convert.ToDateTime(element.Element("DateOfOpening")!.Value),
                Dishes = element.Element("ShopDishes")!.Elements("ShopDish").ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value)),
                Capacity = Convert.ToInt32(element.Element("Capacity")!.Value)
            };
        }
        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOfOpening = model.DateOfOpening;
            Dishes = model.ShopDishes.ToDictionary(x => x.Key, x => x.Value.Item2);
            Capacity = model.Capacity;
        }
        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOfOpening = DateOfOpening,
            ShopDishes = ShopDishes,
            Capacity = Capacity
        };
        public XElement GetXElement => new("Shop",
        new XAttribute("Id", Id),
        new XElement("ShopName", ShopName),
        new XElement("Address", Address),
        new XElement("DateOfOpening", DateOfOpening.ToString()),
        new XElement("ShopDishes", Dishes.Select(x => new XElement("ShopDish", new XElement("Key", x.Key), new XElement("Value", x.Value))).ToArray()),
        new XElement("Capacity",Capacity.ToString()));
    }
}
