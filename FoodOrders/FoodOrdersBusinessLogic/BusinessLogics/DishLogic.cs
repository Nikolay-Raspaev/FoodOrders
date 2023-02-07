using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class DishLogic : IDishLogic
    {
        private readonly ILogger _logger;
        private readonly IDishestorage _Dishestorage;
        public DishLogic(ILogger<DishLogic> logger, IDishestorage
       Dishestorage)
        {
            _logger = logger;
            _Dishestorage = Dishestorage;
        }
        public List<DishViewModel>? ReadList(DishesearchModel? model)
        {
            _logger.LogInformation("ReadList. DishName:{DishName}. Id:{Id}",
                model?.DishName, model?.Id);
            var list = model == null ? _Dishestorage.GetFullList() :
                _Dishestorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public DishViewModel? ReadElement(DishesearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. DishName:{DishName}. Id:{Id}", model.DishName, model.Id);
        var element = _Dishestorage.GetElement(model);
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
            if (_Dishestorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(DishBindingModel model)
        {
            CheckModel(model);
            if (_Dishestorage.Update(model) == null)
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
            if (_Dishestorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(DishBindingModel model, bool withParams =
       true)
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
                throw new ArgumentNullException("Нет названия компонента",
               nameof(model.DishName));
            }
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.Cost));
            }
            _logger.LogInformation("Dish. DishName:{DishName}. Cost:{ Cost}. Id:{Id}", model.DishName, model.Cost, model.Id);
        var element = _Dishestorage.GetElement(new DishesearchModel
        {
            DishName = model.DishName
        });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}