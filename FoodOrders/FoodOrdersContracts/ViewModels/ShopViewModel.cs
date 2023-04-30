using FoodOrdersContracts.Attributes;
using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    public class ShopViewModel : IShopModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column("Название магазина", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public string ShopName { get; set; } = string.Empty;
        [Column("Адрес", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Address { get; set; } = string.Empty;
        [Column("Время открытия", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true, format: "f")]
        public DateTime DateOfOpening { get; set; } = DateTime.Now;
        [Column("Вместимость", gridViewAutoSize: GridViewAutoSize.DisplayedCells, isUseAutoSize: true)]
        public int Capacity { get; set; } = 0;
        [Column(visible: false)]
        public Dictionary<int, (IDishModel, int)> ShopDishes { get; set; } = new();
    }
}
