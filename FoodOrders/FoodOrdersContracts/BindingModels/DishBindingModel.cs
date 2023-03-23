using FoodOrdersDataModels.Models;

namespace FoodOrdersContracts.BindingModels
{
    public class DishBindingModel : IDishModel
    {
        public int Id { get; set; }
        public string DishName { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> DishComponents { get; set; } = new();
    }
}
