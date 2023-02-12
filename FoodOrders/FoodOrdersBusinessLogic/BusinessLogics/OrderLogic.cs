﻿using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Enums;
using Microsoft.Extensions.Logging;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
        }

        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("ReadList. DishName:{DishName}. Id:{Id}", model?.Id);
            var list = model == null ? _orderStorage.GetFullList() :
                _orderStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public bool CreateOrder(OrderBindingModel model)
        {
            CheckModel(model);
            if (model.Status != OrderStatus.Неизвестен)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            model.Status = OrderStatus.Принят;
            if (_orderStorage.Insert(model) == null)
            {
                model.Status = OrderStatus.Неизвестен;
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выдан);
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выполняется);
        }

        public bool FinishOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Готов);
        }

        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.Id < 0)
            {
                throw new ArgumentNullException("Некорректный идентификатор у продукта", nameof(model.Id));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentNullException("Количество продуктов в заказе должно быть больше 0", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentNullException("Сумма заказа должна быть больше 0", nameof(model.Sum));
            }
            _logger.LogInformation("Order. OrderID:{Id}. Sum:{ Sum}. SetOfDishesId: { SetOfDishesId}", model.Id, model.Sum, model.Id);
        }

        //???
        public bool StatusUpdate(OrderBindingModel model, OrderStatus newStatus)
        {
            CheckModel(model);
            if (model.Status + 1 != newStatus)
            {
                _logger.LogWarning("Status update to " + newStatus.ToString() + " operation failed. Order status incorrect.");
                return false;
            }
            model.Status = newStatus;
            if (model.Status == OrderStatus.Выдан) model.DateImplement = DateTime.Now;
            if (_orderStorage.Update(model) == null)
            {
                model.Status--;
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
    }
}