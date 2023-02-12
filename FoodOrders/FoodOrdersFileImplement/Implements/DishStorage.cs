using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersFileImplement.Models;
using System.Reflection.Metadata;

namespace FoodOrdersFileImplement.Implements
{
    public class DishStorage : IDishStorage
    {
        private readonly DataFileSingleton _source;
        public DishStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }
        public List<DishViewModel> GetFullList()
        {
            return _source.Dishes.Select(x => x.GetViewModel).ToList();
        }
        public List<DishViewModel> GetFilteredList(DishSearchModel model)
        {
            if (string.IsNullOrEmpty(model.DishName))
            {
                return new();
            }
            return _source.Dishes.Where(x => x.DishName.Contains(model.DishName)).Select(x => x.GetViewModel).ToList();
        }
        public DishViewModel? GetElement(DishSearchModel model)
        {
            if (string.IsNullOrEmpty(model.DishName) && !model.Id.HasValue)
            {
                return null;
            }
            return _source.Dishes
            .FirstOrDefault(x => (!string.IsNullOrEmpty(model.DishName) && x.DishName == model.DishName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }
        public DishViewModel? Insert(DishBindingModel model)
        {
            model.Id = _source.Dishes.Count > 0 ? _source.Dishes.Max(x => x.Id) + 1 : 1;
            var newDoc = Dish.Create(model);
            if (newDoc == null)
            {
                return null;
            }
            _source.Dishes.Add(newDoc);
            _source.SaveDishes();
            return newDoc.GetViewModel;
        }

        public DishViewModel? Update(DishBindingModel model)
        {
            var dish = _source.Dishes.FirstOrDefault(x => x.Id == model.Id);
            if (dish == null)
            {
                return null;
            }
            dish.Update(model);
            _source.SaveDishes();
            return dish.GetViewModel;
        }

        public DishViewModel? Delete(DishBindingModel model)
        {
            var document = _source.Dishes.FirstOrDefault(x => x.Id == model.Id);
            if (document == null)
            {
                return null;
            }
            document.Update(model);
            _source.SaveDishes();
            return document.GetViewModel;
        }
    }
}