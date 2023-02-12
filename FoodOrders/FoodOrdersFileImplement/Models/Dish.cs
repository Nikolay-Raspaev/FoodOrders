using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using FoodOrdersFileImplement;
using System.Xml.Linq;
namespace FoodOrdersFileImplement.Models
{
    public class Dish : IDishModel
    {
        public int Id { get; private set; }
        public string DishName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, int> Components { get; private set; } = new();
        private Dictionary<int, (IComponentModel, int)>? _dishComponents =
       null;
        public Dictionary<int, (IComponentModel, int)> DishComponents
        {
            get
            {
                if (_dishComponents == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _dishComponents = Components.ToDictionary(x => x.Key, y =>
                    ((source.Components.FirstOrDefault(z => z.Id == y.Key) as IComponentModel)!,
                    y.Value));
                }
                return _dishComponents;
            }
        }
        public static Dish? Create(DishBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Dish()
            {
                Id = model.Id,
                DishName = model.DishName,
                Price = model.Price,
                Components = model.DishComponents.ToDictionary(x => x.Key, x
               => x.Value.Item2)
            };
        }
        public static Dish? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Dish()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                DishName = element.Element("DishName")!.Value,
                Price = Convert.ToDouble(element.Element("Price")!.Value),
                Components =
           element.Element("DishComponents")!.Elements("DishComponent")
            .ToDictionary(x =>
           Convert.ToInt32(x.Element("Key")?.Value), x =>
           Convert.ToInt32(x.Element("Value")?.Value))
            };
        }
        public void Update(DishBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            DishName = model.DishName;
            Price = model.Price;
            Components = model.DishComponents.ToDictionary(x => x.Key, x =>
           x.Value.Item2);
            _dishComponents = null;
        }
        public DishViewModel GetViewModel => new()
        {
            Id = Id,
            DishName = DishName,
            Price = Price,
            DishComponents = DishComponents
        };
        public XElement GetXElement => new("Dish",
        new XAttribute("Id", Id),
        new XElement("DishName", DishName),
        new XElement("Price", Price.ToString()),
        new XElement("DishComponents", Components.Select(x =>
       new XElement("DishComponent",

       new XElement("Key", x.Key),

       new XElement("Value", x.Value)))

       .ToArray()));
    }
}
