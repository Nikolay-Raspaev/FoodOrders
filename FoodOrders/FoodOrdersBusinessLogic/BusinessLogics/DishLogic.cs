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
    public class DishLogic : IDishLogic
    {
        private readonly ILogger _logger;
        private readonly IDishStorage _dishStorage;
        public DishLogic(ILogger<DishLogic> logger, IDishStorage dishStorage)
        {
            _logger = logger;
            _dishStorage = dishStorage;
        }

        public List<DishViewModel>? ReadList(DishSearchModel? model)
        {
            _logger.LogInformation("ReadList. DishName:{DishName}. Id:{Id}",
                model?.DishName, model?.Id);
            var list = model == null ? _dishStorage.GetFullList() :
                _dishStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public DishViewModel? ReadElement(DishSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. DishName:{DishName}. Id:{Id}", model.DishName, model.Id);
            var element = _dishStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(DishBindingModel model)
        {
            CheckModel(model);
            if (_dishStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(DishBindingModel model)
        {
            CheckModel(model);
            if (_dishStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(DishBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_dishStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(DishBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.DishName))
            {
                throw new ArgumentNullException("Нет названия компонента", nameof(model.DishName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("Dish. DishName:{DishName}. Price:{Price}. Id:{Id}", model.DishName, model.Price, model.Id);
            var element = _dishStorage.GetElement(new DishSearchModel
            {
                DishName = model.DishName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Продукт с таким названием уже есть");
            }
        }
    }
}
