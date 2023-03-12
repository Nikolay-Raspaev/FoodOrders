using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using FoodOrdersFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersFileImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        private readonly DataFileSingleton source;
        public ShopStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public ShopViewModel? Delete(ShopBindingModel model)
        {
            var element = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                source.Shops.Remove(element);
                source.SaveShops();
                return element.GetViewModel;
            }
            return null;
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Shops
            .FirstOrDefault(x =>
            (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            return source.Shops
            .Where(x => x.ShopName.Contains(model.ShopName))
            .Select(x => x.GetViewModel)
            .ToList();
        }

        public List<ShopViewModel> GetFullList()
        {
            return source.Shops.Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = source.Shops.Count > 0 ? source.Shops.Max(x =>
           x.Id) + 1 : 1;
            var newShop = Shop.Create(model);
            if (newShop == null)
            {
                return null;
            }
            source.Shops.Add(newShop);
            source.SaveShops();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            var shop = source.Shops.FirstOrDefault(x => x.Id ==
           model.Id);
            if (shop == null)
            {
                return null;
            }
            shop.Update(model);
            source.SaveShops();
            return shop.GetViewModel;
        }
        public bool SellDishes(IDishModel dish, int count)
        {
            if (dish == null || count < 1) return false;
            List<Shop> shopsWithDish = source.Shops.Where(x => x.ShopDishes.ContainsKey(dish.Id)).ToList();
            if (shopsWithDish.Sum(x => x.ShopDishes[dish.Id].Item2) < count)
            {
                return false;
            }
            foreach(var shop in shopsWithDish)
            {
                int dishInShopCount = shop.ShopDishes[dish.Id].Item2;
                if(count - dishInShopCount >= 0)
                {
                    count -= dishInShopCount;
                    shop.ShopDishes.Remove(dish.Id);
                }
                else
                {
                    shop.ShopDishes[dish.Id] = (dish, shop.ShopDishes[dish.Id].Item2 - count);
                    count = 0;
                }
                Update(new ShopBindingModel
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    Address = shop.Address,
                    DateOfOpening = shop.DateOfOpening,
                    ShopDishes = shop.ShopDishes,
                    Capacity = shop.Capacity
                });
                if (count == 0) break;
            }
            return true;
        }
    }
}
