using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            using var context = new FoodOrdersDatabase();
            if (model.Id.HasValue)
                return context.Clients
                    .FirstOrDefault(x => x.Id == model.Id)?
                    .GetViewModel;
            if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
                return context.Clients
                    .FirstOrDefault(x => x.Email
                    .Equals(model.Email) && x.Password
                    .Equals(model.Password))?
                    .GetViewModel;
            if (!string.IsNullOrEmpty(model.Email))
                return context.Clients
                    .FirstOrDefault(x => x.Email.Equals(model.Email))?.GetViewModel;
            return null;
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            {
                if (string.IsNullOrEmpty(model.Email))
                {
                    return new();
                }
                using var context = new FoodOrdersDatabase();
                return context.Clients
                        .Where(x => x.Email.Contains(model.Email))
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
        }

        public List<ClientViewModel> GetFullList()
        {
            using var context = new FoodOrdersDatabase();
            return context.Clients
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            context.Clients.Add(newClient);
            context.SaveChanges();
            return newClient.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            context.SaveChanges();
            return client.GetViewModel;
        }
    }
}