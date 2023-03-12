using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using Microsoft.Extensions.Logging;
using System.Text;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;
        private readonly IShopStorage _shopStorage;
        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
        }
        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        public bool DeliveryDishes(ShopSearchModel model, IDishModel dish, int count)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }
            if(count <= 0)
            {
                throw new ArgumentNullException("Количество должно быть больше 0", nameof(count));
            }
            _logger.LogInformation("DeliveryDishes. ShopName:{ShopName}.Id:{Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);
            if(element == null)
            {
                _logger.LogWarning("Shop not found");
                return false;
            }
            if (element.Capacity - element.ShopDishes.Sum(x => x.Value.Item2) < count)
            {
                throw new InvalidOperationException("В магазине нет места под такое количество блюд");
            }
            if (element.ShopDishes.ContainsKey(dish.Id))
            {
                element.ShopDishes[dish.Id] = (dish, element.ShopDishes[dish.Id].Item2 + count);
            }
            else
            {
                element.ShopDishes[dish.Id] = (dish, count);
            }
            _shopStorage.Update(new ShopBindingModel
            {
                Id = element.Id,
                ShopName = element.ShopName,
                Address = element.Address,
                DateOfOpening = element.DateOfOpening,
                ShopDishes = element.ShopDishes,
                Capacity = element.Capacity
            });
            return true;
        }
        public ShopViewModel? ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ShopName:{ShopName}.Id:{Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public List<ShopViewModel>? ReadList(ShopSearchModel? model)
        {
            _logger.LogInformation("ReadList. ShopName:{ShopName}.Id:{Id}", model?.ShopName, model?.Id);
            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentNullException("Нет названия магазина", nameof(model.ShopName));
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                throw new ArgumentNullException("Нет адреса магазина", nameof(model.Address));
            }
            _logger.LogInformation("Shop. ShopName:{ShopName}.Address:{ Address}. Id: {Id}", model.ShopName, model.Address, model.Id);
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }
        public bool SellDishes(IDishModel dish, int count)
        {
            return _shopStorage.SellDishes(dish, count);
        }
        public bool AddDishes(IDishModel dish, int count)
        {
            if (dish == null || count < 1)
            {
                return false;
            }
            List<ShopViewModel> shopsList = _shopStorage.GetFullList();
            if (shopsList.Sum(x => x.Capacity) - shopsList.Sum(x => x.ShopDishes.Sum(y => y.Value.Item2)) < count)
            {
                return false;
            }
            foreach (ShopViewModel shop in shopsList)
            {
                int emptySpace = shop.Capacity - shop.ShopDishes.Sum(x => x.Value.Item2);
                if (emptySpace < count)
                {
                    DeliveryDishes(new ShopSearchModel { Id = shop.Id }, dish, emptySpace);
                    count -= emptySpace;
                }
                else
                {
                    DeliveryDishes(new ShopSearchModel { Id = shop.Id }, dish, count);
                    break;
                }
            }
            return true;
        }
    }
}
