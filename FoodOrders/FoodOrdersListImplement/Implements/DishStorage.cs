using FoodOrdersListImplement.Models;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersListImplement.Implements
{
    public class DishStorage : IDishStorage
    {
        private readonly DataListSingleton _source;
        public DishStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<DishViewModel> GetFullList()
        {
            var result = new List<DishViewModel>();
            foreach (var dish in _source.Dish)
            {
                result.Add(dish.GetViewModel);
            }
            return result;
        }
        public List<DishViewModel> GetFilteredList(DishSearchModel
       model)
        {
            var result = new List<DishViewModel>();
            if (string.IsNullOrEmpty(model.DishName))
            {
                return result;
            }
            foreach (var dish in _source.Dish)
            {
                if (dish.DishName.Contains(model.DishName))
                {
                    result.Add(dish.GetViewModel);
                }
            }
            return result;
        }
        public DishViewModel? GetElement(DishSearchModel model)
        {
            if (string.IsNullOrEmpty(model.DishName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var dish in _source.Dish)
            {
                if ((!string.IsNullOrEmpty(model.DishName) &&
                dish.DishName == model.DishName) ||
                (model.Id.HasValue && dish.Id == model.Id))
                {
                    return dish.GetViewModel;
                }
            }
            return null;
        }
        public DishViewModel? Insert(DishBindingModel model)
        {
            model.Id = 1;
            foreach (var dish in _source.Dish)
            {
                if (model.Id <= dish.Id)
                {
                    model.Id = dish.Id + 1;
                }
            }
            var newDish = Dish.Create(model);
            if (newDish == null)
            {
                return null;
            }
            _source.Dish.Add(newDish);
            return newDish.GetViewModel;
        }
        public DishViewModel? Update(DishBindingModel model)
        {
            foreach (var dish in _source.Dish)
            {
                if (dish.Id == model.Id)
                {
                    dish.Update(model);
                    return dish.GetViewModel;
                }
            }
            return null;
        }
        public DishViewModel? Delete(DishBindingModel model)
        {
            for (int i = 0; i < _source.Dish.Count; ++i)
            {
                if (_source.Dish[i].Id == model.Id)
                {
                    var element = _source.Dish[i];
                    _source.Dish.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}