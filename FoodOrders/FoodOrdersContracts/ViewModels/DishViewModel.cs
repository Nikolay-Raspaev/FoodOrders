using FoodOrdersDataModels.Models;
using System.ComponentModel;
namespace FoodOrdersContracts.ViewModels
{
    public class DishViewModel : IDishModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string DishName { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Cost { get; set; }
    }
}
