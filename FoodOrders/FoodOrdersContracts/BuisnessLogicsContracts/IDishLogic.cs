using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IDishLogic
    {
        List<DishViewModel>? ReadList(DishSearchModel? model);
        DishViewModel? ReadElement(DishSearchModel model);
        bool Create(DishBindingModel model);
        bool Update(DishBindingModel model);
        bool Delete(DishBindingModel model);
    }
}