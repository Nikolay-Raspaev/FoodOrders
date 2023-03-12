using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface IShopStorage
    {
        List<ShopViewModel> GetFullList();
        List<ShopViewModel> GetFilteredList(ShopSearchModel model);
        ShopViewModel? GetElement(ShopSearchModel model);
        ShopViewModel? Insert(ShopBindingModel model);
        ShopViewModel? Update(ShopBindingModel model);
        ShopViewModel? Delete(ShopBindingModel model);
        bool SellDishes(IDishModel dish, int count);
    }
}
