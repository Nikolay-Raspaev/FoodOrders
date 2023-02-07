using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface IDishestorage
    {
        List<DishViewModel> GetFullList();
        List<DishViewModel> GetFilteredList(DishesearchModel model);
        DishViewModel? GetElement(DishesearchModel model);
        DishViewModel? Insert(DishBindingModel model);
        DishViewModel? Update(DishBindingModel model);
        DishViewModel? Delete(DishBindingModel model);
    }
}
