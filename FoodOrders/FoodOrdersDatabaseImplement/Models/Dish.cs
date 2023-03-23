using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrdersDatabaseImplement.Models
{
    public class Dish : IDishModel
    {
        public int Id { get; set; }

        [Required]
        public string DishName { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }

        private Dictionary<int, (IComponentModel, int)>? _dishComponents = null;

        //??
        [NotMapped]
        public Dictionary<int, (IComponentModel, int)> DishComponents
        {
            get
            {
                if (_dishComponents == null)
                {
                    _dishComponents = Components.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component as IComponentModel, recPC.Count));
                }
                return _dishComponents;
            }
        }

        [ForeignKey("DishId")]
        public virtual List<DishComponent> Components { get; set; } = new();

        public static Dish Create(FoodOrdersDatabase context, DishBindingModel model)
        {
            return new Dish()
            {
                Id = model.Id,
                DishName = model.DishName,
                Price = model.Price,
                Components = model.DishComponents.Select(x => new DishComponent
                {
                    Component = context.Components.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }

        public void Update(DishBindingModel model)
        {
            DishName = model.DishName;
            Price = model.Price;
        }

        public DishViewModel GetViewModel => new()
        {
            Id = Id,
            DishName = DishName,
            Price = Price,
            DishComponents = DishComponents
        };

        public void UpdateComponents(FoodOrdersDatabase context, DishBindingModel model)
        {
            var dishComponents = context.DishComponents.Where(rec => rec.DishId == model.Id).ToList();
            if (dishComponents != null && dishComponents.Count > 0)
            {   // удалили те в бд, которых нет в модели
                context.DishComponents.RemoveRange(dishComponents.Where(rec => !model.DishComponents.ContainsKey(rec.ComponentId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in dishComponents)
                {
                    updateComponent.Count = model.DishComponents[updateComponent.ComponentId].Item2;
                    model.DishComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            var dish = context.Dishes.First(x => x.Id == Id);
            //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
            foreach (var dc in model.DishComponents)
            {
                context.DishComponents.Add(new DishComponent
                {
                    Dish = dish,
                    Component = context.Components.First(x => x.Id == dc.Key),
                    Count = dc.Value.Item2
                });
                context.SaveChanges();
            }
            _dishComponents = null;
        }
    }
}