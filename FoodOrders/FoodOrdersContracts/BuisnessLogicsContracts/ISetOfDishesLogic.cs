using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface ISetOfDishesLogic
    {
        List<SetOfDishesViewModel>? ReadList(SetOfDishesearchModel? model);
        SetOfDishesViewModel? ReadElement(SetOfDishesearchModel model);
        bool Create(SetOfDishesBindingModel model);
        bool Update(SetOfDishesBindingModel model);
        bool Delete(SetOfDishesBindingModel model);
    }
}