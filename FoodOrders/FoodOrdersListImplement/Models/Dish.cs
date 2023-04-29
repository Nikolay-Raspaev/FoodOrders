using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.Runtime.Serialization;

namespace FoodOrdersListImplement.Models
{
    public class Dish : IDishModel
    {
        public int Id { get; private set; }
        public string DishName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, (IComponentModel, int)> DishComponents
        {
            get;
            private set;
        } = new Dictionary<int, (IComponentModel, int)>();
        public static Dish? Create(DishBindingModel? model)
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
                DishComponents = model.DishComponents
            };
        }
        public void Update(DishBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            DishName = model.DishName;
            Price = model.Price;
            DishComponents = model.DishComponents;
        }
        public DishViewModel GetViewModel => new()
        {
            Id = Id,
            DishName = DishName,
            Price = Price,
            DishComponents = DishComponents
        };
    }
}