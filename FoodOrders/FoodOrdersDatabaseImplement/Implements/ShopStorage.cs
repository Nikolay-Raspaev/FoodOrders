using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement;
using FoodOrdersDataModels.Models;
using FoodOrdersDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class ShopStorage : IShopStorage
    {


        public List<ShopViewModel> GetFullList()
        {
            using var context = new FoodOrdersDatabase();
            return context.Shops
                .Include(x => x.Dishes)
                .ThenInclude(x => x.Dish)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            using var context = new FoodOrdersDatabase();
            return context.Shops
                .Include(x => x.Dishes)
                .ThenInclude(x => x.Dish)
                .Where(x => x.ShopName.Contains(model.ShopName))
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            return context.Shops
                .Include(x => x.Dishes)
                .ThenInclude(x => x.Dish)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var newShop = Shop.Create(context, model);
            if (newShop == null)
            {
                return null;
            }
            context.Shops.Add(newShop);
            context.SaveChanges();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            using var transaction = context.Database.BeginTransaction();
            
            try 
            {
                var updateShop = context.Shops.FirstOrDefault(x => x.Id == model.Id);
                if (updateShop == null)
                {
                    return null;
                }
                updateShop.Update(model);
                context.SaveChanges();
                updateShop.UpdateDish(context, model);
                transaction.Commit();
                return updateShop.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
           
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var element = context.Shops
                .Include(x => x.Dishes)
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Shops.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public bool SellDishes(IDishModel dish, int count)
        {
            using var context = new FoodOrdersDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                List<ShopDish> ListShopDish = context.ShopDishes
                    .Include(x => x.Shop)
                    .Where(y => y.DishId == dish.Id)
                    .ToList();

                if (ListShopDish == null) return false;

                foreach (var shopDish in ListShopDish)
                {
                    if (count - shopDish.Count >= 0)
                    {
                        count -= shopDish.Count;
                        ListShopDish.Remove(shopDish);
                    }
                    else
                    {
                        shopDish.Count -= count;
                        count = 0;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch 
            {
                transaction.Rollback();
                throw;
            }         
        }
    }
}
