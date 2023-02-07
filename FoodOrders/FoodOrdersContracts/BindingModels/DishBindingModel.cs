using FoodOrdersDataModels.Models;

namespace FoodOrdersContracts.BindingModels
{
    public class DishBindingModel : IDishModel
    {
        public int Id { get; set; }
        public string DishName { get; set; } = string.Empty;
        public double Cost { get; set; }
    }
}