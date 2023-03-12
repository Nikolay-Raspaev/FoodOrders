using FoodOrdersDataModels.Models;

namespace FoodOrdersContracts.BindingModels
{
    public class ShopBindingModel : IShopModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfOpening { get; set; } = DateTime.Now;
        public Dictionary<int, (IDishModel, int)> ShopDishes { get; set; } = new();
    }
}
