using FoodOrdersContracts.Attributes;
using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    public class DishViewModel : IDishModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column("Название блюда", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string DishName { get; set; } = string.Empty;
        [Column("Цена", width: 100, format: "0.00")]
        public double Price { get; set; }
        [Column(visible: false)]
        public Dictionary<int, (IComponentModel, int)> DishComponents {get; set;} = new();
    }
}
