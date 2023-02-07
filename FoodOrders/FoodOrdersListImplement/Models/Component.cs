using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersListImplement.Models
{
    public class Dish : IDishModel
    {
        public int Id { get; private set; }
        public string DishName { get; private set; } = string.Empty;
        public double Cost { get; set; }
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
                Cost = model.Cost
            };
        }
        public void Update(DishBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            DishName = model.DishName;
            Cost = model.Cost;
        }
        public DishViewModel GetViewModel => new()
        {
            Id = Id,
            DishName = DishName,
            Cost = Cost
        };
    }
}