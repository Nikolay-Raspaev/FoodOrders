using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersListImplement.Models;

namespace FoodOrdersListImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataListSingleton _source;
        public ClientStorage()
        {
            _source = DataListSingleton.GetInstance();
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
        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var component in _source.Clients)
            {
                if ((!string.IsNullOrEmpty(model.Email) &&
                component.Email == model.Email) ||
                (model.Id.HasValue && component.Id == model.Id))
                {
                    return component.GetViewModel;
                }
            }
            return null;
        }
        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = 1;
            foreach (var component in _source.Clients)
            {
                if (model.Id <= component.Id)
                {
                    model.Id = component.Id + 1;
                }
            }
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            _source.Clients.Add(newClient);
            return newClient.GetViewModel;
        }
        public ClientViewModel? Update(ClientBindingModel model)
        {
            foreach (var component in _source.Clients)
            {
                if (component.Id == model.Id)
                {
                    component.Update(model);
                    return component.GetViewModel;
                }
            }
            return null;
        }
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            for (int i = 0; i < _source.Clients.Count; ++i)
            {
                if (_source.Clients[i].Id == model.Id)
                {
                    var element = _source.Clients[i];
                    _source.Clients.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}