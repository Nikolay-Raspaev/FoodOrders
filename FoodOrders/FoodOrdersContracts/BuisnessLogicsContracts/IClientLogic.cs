using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IClientLogic
    {
        List<ClientViewModel>? ReadList(ClientSearchModel? model);

        ClientViewModel? ReadElement(ClientSearchModel model);

        bool Create(ClientBindingModel model);

        bool Update(ClientBindingModel model);

        bool Delete(ClientBindingModel model);
    }
}