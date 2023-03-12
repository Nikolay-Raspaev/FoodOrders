using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.Reflection;
using System.Xml.Linq;

namespace FoodOrdersListImplement.Models
{
    public class Shop : IShopModel
    {
        public string ShopName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public DateTime DateOfOpening { get; private set; } = DateTime.Now;
        public int Id { get; private set; }
        public Dictionary<int, (IDishModel, int)> ShopDishes
        {
            get;
            private set;
        } = new Dictionary<int, (IDishModel, int)>();
        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOfOpening = model.DateOfOpening,
                ShopDishes = model.ShopDishes
            };
        }
        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOfOpening = model.DateOfOpening;
            ShopDishes = model.ShopDishes;
        }
        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOfOpening = DateOfOpening,
            ShopDishes = ShopDishes
        };
    }
}
