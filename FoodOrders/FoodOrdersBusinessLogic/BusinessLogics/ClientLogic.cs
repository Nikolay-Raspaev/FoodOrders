using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
        private readonly ILogger _logger;
        private readonly IClientStorage _clienttStorage;
        public ClientLogic(ILogger<ClientLogic> logger, IClientStorage ClientStorage)
        {
            _logger = logger;
            _clienttStorage = ClientStorage;
        }
        public bool Create(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clienttStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ClientBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_clienttStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        public ClientViewModel? ReadElement(ClientSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("Client. ClientFIO:{ClientFIO}. Email:{Email}. Id:{Id}", model.ClientFIO, model.Email, model.Id);
            var element = _clienttStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public List<ClientViewModel>? ReadList(ClientSearchModel? model)
        {
            _logger.LogInformation("Client. ClientFIO:{ClientFIO}. Email:{Email}. Id:{Id}", model?.ClientFIO, model?.Email, model?.Id);
            var list = model == null ? _clienttStorage.GetFullList() : _clienttStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public bool Update(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clienttStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(ClientBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ClientFIO))
            {
                throw new ArgumentNullException("Нет ФИО клиента", nameof(model.ClientFIO));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentNullException("Нет логина клиента", nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentNullException("Нет пароля клиента", nameof(model.Password));
            }
            if (!Regex.IsMatch(model.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Неправильно введенный email", nameof(model.Email));
            }
            if (!Regex.IsMatch(model.Password, @"^^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Неправильно введенный пароль", nameof(model.Password));
            }
            _logger.LogInformation("Client. ClientFIO:{ClientFIO}. Email:{Email}. Password:{Password} Id:{Id}", model.ClientFIO, model.Email, model.Password, model.Id);
            var element = _clienttStorage.GetElement(new ClientSearchModel
            {
                Email = model.Email
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Клиент с таким логином уже есть");
            }
        }
    }
}