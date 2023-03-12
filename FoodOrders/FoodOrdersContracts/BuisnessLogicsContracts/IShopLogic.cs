using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IShopLogic
    {
        List<ShopViewModel>? ReadList(ShopSearchModel? model);
        ShopViewModel? ReadElement(ShopSearchModel model);
        bool Create(ShopBindingModel model);
        bool Update(ShopBindingModel model);
        bool Delete(ShopBindingModel model);
        bool DeliveryDishes(ShopSearchModel model, IDishModel dish, int count);
        bool SellDishes(IDishModel dish, int count);
        bool AddDishes(IDishModel dish, int count);
    }
}
