using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using FoodOrdersDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FoodOrdersDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }

        [Required]
        public string ShopName { get; private set; } = string.Empty;

        [Required]
        public string Address { get; private set; } = string.Empty;

        [Required]
        public DateTime DateOfOpening { get; private set; } = DateTime.Now;

        [Required]
        public int Capacity { get; private set; } = 0;

        [NotMapped]

        public Dictionary<int, (IDishModel, int)>? _shopDishes = null;

        [NotMapped]
        public Dictionary<int, (IDishModel, int)> ShopDishes
        {
            get
            {
                if (_shopDishes == null)
                {
                    _shopDishes = Dishes.ToDictionary(recSD => recSD.DishId, recSD => (recSD.Dish as IDishModel, recSD.Count));
                }
                return _shopDishes;
            }
        }

        [ForeignKey("ShopId")]
        public virtual List<ShopDish> Dishes { get; set; } = new();

        public static Shop? Create(FoodOrdersDatabase context, ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOfOpening = model.DateOfOpening,
                Dishes = model.ShopDishes.Select(x => new ShopDish
                {
                    Dish = context.Dishes.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList(),
                Capacity = model.Capacity
            };
        }
       
        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOfOpening = model.DateOfOpening;
            Capacity = model.Capacity;
        }
        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOfOpening = DateOfOpening,
            ShopDishes = ShopDishes,
            Capacity = Capacity
        };
        public void UpdateDish(FoodOrdersDatabase context, ShopBindingModel model)
        {
            var shopDishes = context.ShopDishes.Where(rec => rec.ShopId == model.Id).ToList();
            if (shopDishes != null && shopDishes.Count > 0)
            {   // удалили те в бд, которых нет в модели
                context.ShopDishes.RemoveRange(shopDishes.Where(rec => !model.ShopDishes.ContainsKey(rec.DishId)));
                context.SaveChanges();
                shopDishes = context.ShopDishes.Where(rec => rec.ShopId == model.Id).ToList();
                // обновили количество у существующих записей
                foreach (var updateDish in shopDishes)
                {
                    updateDish.Count = model.ShopDishes[updateDish.DishId].Item2;
                    model.ShopDishes.Remove(updateDish.DishId);
                }
                context.SaveChanges();
            }
            var shop = context.Shops.First(x => x.Id == Id);
            //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
            foreach (var sd in model.ShopDishes)
            {
                context.ShopDishes.Add(new ShopDish
                {
                    Shop = shop,
                    Dish = context.Dishes.First(x => x.Id == sd.Key),
                    Count = sd.Value.Item2
                });
                context.SaveChanges();
            }
            _shopDishes = null;
        }
    }
}
