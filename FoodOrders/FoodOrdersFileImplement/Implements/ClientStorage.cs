using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersFileImplement.Models;

namespace FoodOrdersFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataFileSingleton _source;
        public ClientStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }
        public List<ClientViewModel> GetFullList()
        {
            return _source.Clients.Select(x => x.GetViewModel).ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return new();
            }
            return _source.Clients.Where(x => x.Email.Contains(model.Email)).Select(x => x.GetViewModel).ToList();
        }

        //FirstOrDefault выбирается первый или ничего, то есть вернёт первое совпадение или null
        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
            {
                return null;
            }
            return _source.Clients.FirstOrDefault(x => (!string.IsNullOrEmpty(model.Email) && x.Email == model.Email) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }
        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = _source.Clients.Count > 0 ? _source.Clients.Max(x => x.Id) + 1 : 1;
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            _source.Clients.Add(newClient);
            _source.SaveClients();
            return newClient.GetViewModel;
        }
        public ClientViewModel? Update(ClientBindingModel model)
        {
            var component = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (component == null)
            {
                return null;
            }
            component.Update(model);
            _source.SaveClients();
            return component.GetViewModel;
        }
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var element = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                _source.Clients.Remove(element);
                _source.SaveClients();
                return element.GetViewModel;
            }
            return null;
        }
    }
}