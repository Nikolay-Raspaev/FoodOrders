using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ClientViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}