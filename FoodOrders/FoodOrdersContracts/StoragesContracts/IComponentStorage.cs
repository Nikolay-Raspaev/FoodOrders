using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface IComponentStorage
    {
        List<ComponentViewModel> GetFullList();
        List<ComponentViewModel> GetFilteredList(ComponentSearchModel model);
        ComponentViewModel? GetElement(ComponentSearchModel model);
        ComponentViewModel? Insert(ComponentBindingModel model);
        ComponentViewModel? Update(ComponentBindingModel model);
        ComponentViewModel? Delete(ComponentBindingModel model);
    }
}
