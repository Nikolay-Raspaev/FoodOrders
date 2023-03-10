using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    public class DishViewModel : IDishModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string DishName { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> DishComponents {get; set;} = new();
    }
}
