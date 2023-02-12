using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface IDishStorage
    {
        List<DishViewModel> GetFullList();
        List<DishViewModel> GetFilteredList(DishSearchModel model);
        DishViewModel? GetElement(DishSearchModel model);
        DishViewModel? Insert(DishBindingModel model);
        DishViewModel? Update(DishBindingModel model);
        DishViewModel? Delete(DishBindingModel model);
    }
}