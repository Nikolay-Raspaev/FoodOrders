using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model);

        ImplementerViewModel? ReadElement(ImplementerSearchModel model);

        bool Create(ImplementerBindingModel model);

        bool Update(ImplementerBindingModel model);

        bool Delete(ImplementerBindingModel model);
    }
}