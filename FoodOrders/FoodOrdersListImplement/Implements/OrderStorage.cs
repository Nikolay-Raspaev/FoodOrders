using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton _source;
        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in _source.Orders)
            {
                result.Add(GetViewModel(order));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();
            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return _source.Orders.Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => GetViewModel(x))
                    .ToList();
            }
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    result.Add(GetViewModel(order));
                }
            }
            return result;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            foreach (var order in _source.Orders)
            {
                if (model.Id.HasValue && order.Id == model.Id)
                {
                    return GetViewModel(order);
                }
            }
            return null;
        }

        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            foreach (var dish in _source.Dishes)
            {
                if (dish.Id == order.DishId)
                {
                    viewModel.DishName = dish.DishName;
                    break;
                }
            }
            return viewModel;
        }

        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);
                    return GetViewModel(element);
                }
            }
            return null;
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = 1;
            foreach (var order in _source.Orders)
            {
                if (model.Id <= order.Id)
                {
                    model.Id = order.Id + 1;
                }
            }
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            _source.Orders.Add(newOrder);
            return GetViewModel(newOrder);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    order.Update(model);
                    return GetViewModel(order);
                }
            }
            return null;
        }
    }
}
