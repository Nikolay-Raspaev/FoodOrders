using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class SetOfDishesLogic : ISetOfDishesLogic
    {
        private readonly ILogger _logger;
        private readonly ISetOfDishestorage _set_of_dishesStorage;
        public SetOfDishesLogic(ILogger<SetOfDishesLogic> logger, ISetOfDishestorage set_of_dishesStorage)
        {
            _logger = logger;
            _set_of_dishesStorage = set_of_dishesStorage;
        }

        public List<SetOfDishesViewModel>? ReadList(SetOfDishesearchModel? model)
        {
            _logger.LogInformation("ReadList. SetOfDishesName:{SetOfDishesName}. Id:{Id}",
                model?.SetOfDishesName, model?.Id);
            var list = model == null ? _set_of_dishesStorage.GetFullList() :
                _set_of_dishesStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public SetOfDishesViewModel? ReadElement(SetOfDishesearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. SetOfDishesName:{SetOfDishesName}. Id:{Id}", model.SetOfDishesName, model.Id);
            var element = _set_of_dishesStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(SetOfDishesBindingModel model)
        {
            CheckModel(model);
            if (_set_of_dishesStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(SetOfDishesBindingModel model)
        {
            CheckModel(model);
            if (_set_of_dishesStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(SetOfDishesBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_set_of_dishesStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(SetOfDishesBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.SetOfDishesName))
            {
                throw new ArgumentNullException("Нет названия компонента", nameof(model.SetOfDishesName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("SetOfDishes. SetOfDishesName:{SetOfDishesName}. Price:{Price}. Id:{Id}", model.SetOfDishesName, model.Price, model.Id);
            var element = _set_of_dishesStorage.GetElement(new SetOfDishesearchModel
            {
                SetOfDishesName = model.SetOfDishesName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Прдукт с таким названием уже есть");
            }
        }
    }
}
