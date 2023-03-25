using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersListImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataListSingleton _source;
        public ClientStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
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
            var result = new List<ClientViewModel>();
            if (string.IsNullOrEmpty(model.Email))
            {
                return result;
            }
            foreach (var component in _source.Clients)
            {
                if (component.Email.Contains(model.Email))
                {
                    result.Add(component.GetViewModel);
                }
            }
            return result;
        }

        public List<ClientViewModel> GetFullList()
        {
            var result = new List<ClientViewModel>();
            foreach (var component in _source.Clients)
            {
                result.Add(component.GetViewModel);
            }
            return result;
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