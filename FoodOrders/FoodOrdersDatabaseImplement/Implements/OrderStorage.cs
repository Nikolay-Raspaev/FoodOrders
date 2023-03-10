using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var element = context.Orders
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            return context.Orders
                .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                ?.GetViewModel;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            using var context = new FoodOrdersDatabase();
            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return context.Orders
                .Include(x => x.Dish)
                .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                .Select(x => x.GetViewModel)
                .ToList();
            }
            return context.Orders
                .Include(x => x.Dish)
                .Where(x => x.Id == model.Id)
                .Select(x => x.GetViewModel)
                .ToList();
        }

        private static OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            using var context = new FoodOrdersDatabase();
            var element = context.Dishes
                .FirstOrDefault(x => x.Id == order.DishId);
            viewModel.DishName = element.DishName;
            return viewModel;
        }

        public List<OrderViewModel> GetFullList()
        {
            using var context = new FoodOrdersDatabase();
            return context.Orders
                    .Select(x => new OrderViewModel
                    {
                        Id = x.Id,
                        DishId = x.DishId,
                        Count = x.Count,
                        Sum = x.Sum,
                        Status = x.Status,
                        DateCreate = x.DateCreate,
                        DateImplement = x.DateImplement,
                        DishName = x.Dish.DishName
                    })
                    .ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return newOrder.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return order.GetViewModel;
        }
    }
}
