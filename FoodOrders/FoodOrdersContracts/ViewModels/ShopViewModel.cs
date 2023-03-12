using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    public class ShopViewModel : IShopModel
    {
        public int Id { get; set; }
        [DisplayName("Название магазина")]
        public string ShopName { get; set; } = string.Empty;
        [DisplayName("Адрес")]
        public string Address { get; set; } = string.Empty;
        [DisplayName("Дата открытия")]
        public DateTime DateOfOpening { get; set; } = DateTime.Now;
        [DisplayName("Вместимость")]
        public int Capacity { get; set; } = 0;
        public Dictionary<int, (IDishModel, int)> ShopDishes { get; set; } = new();
    }
}
