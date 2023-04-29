using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new FoodOrdersDatabase();
            return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue && !model.DateFrom.HasValue && !model.ClientId.HasValue && !model.Status.HasValue && !model.ImplementerId.HasValue)
            {
                return new();
            }
            using var context = new FoodOrdersDatabase();
            if (model.Status.HasValue && model.ImplementerId.HasValue)
            {
                return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            if (model.ClientId.HasValue)
            {
                return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.ClientId == model.ClientId)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            if (model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            if (model.Status != null)
            {
                return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => model.Status == x.Status)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return context.Orders
                .Include(x => x.Dish)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .Where(x => x.Id == model.Id)
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            using var context = new FoodOrdersDatabase();
            if (model.Id.HasValue)
            {
                return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                    ?.GetViewModel;
            }        
            else if (model.Status.HasValue && model.ImplementerId.HasValue)
            {
                return context.Orders
                    .Include(x => x.Dish)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .FirstOrDefault(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)
                    ?.GetViewModel;
            }
            return null;
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
            return context.Orders
                .Include(x => x.Dish)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .FirstOrDefault(x => x.Id == newOrder.Id)
                 ?.GetViewModel;
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
            return context.Orders
                .Include(x => x.Dish)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .FirstOrDefault(x => x.Id == order.Id)
                 ?.GetViewModel;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
