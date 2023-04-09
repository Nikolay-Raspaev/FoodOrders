using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientSearchModel model);

        ClientViewModel? GetElement(ClientSearchModel model);

        ClientViewModel? Insert(ClientBindingModel model);

        ClientViewModel? Update(ClientBindingModel model);

        ClientViewModel? Delete(ClientBindingModel model);
    }
}