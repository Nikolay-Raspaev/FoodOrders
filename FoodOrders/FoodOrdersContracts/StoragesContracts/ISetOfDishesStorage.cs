using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface ISetOfDishestorage
    {
        List<SetOfDishesViewModel> GetFullList();
        List<SetOfDishesViewModel> GetFilteredList(SetOfDishesearchModel model);
        SetOfDishesViewModel? GetElement(SetOfDishesearchModel model);
        SetOfDishesViewModel? Insert(SetOfDishesBindingModel model);
        SetOfDishesViewModel? Update(SetOfDishesBindingModel model);
        SetOfDishesViewModel? Delete(SetOfDishesBindingModel model);
    }
}