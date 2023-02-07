using FoodOrdersListImplement.Models;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersListImplement.Implements
{
    public class SetOfDishestorage : ISetOfDishestorage
    {
        private readonly DataListSingleton _source;
        public SetOfDishestorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<SetOfDishesViewModel> GetFullList()
        {
            var result = new List<SetOfDishesViewModel>();
            foreach (var set_of_dishes in _source.SetOfDishes)
            {
                result.Add(set_of_dishes.GetViewModel);
            }
            return result;
        }
        public List<SetOfDishesViewModel> GetFilteredList(SetOfDishesearchModel
       model)
        {
            var result = new List<SetOfDishesViewModel>();
            if (string.IsNullOrEmpty(model.SetOfDishesName))
            {
                return result;
            }
            foreach (var set_of_dishes in _source.SetOfDishes)
            {
                if (set_of_dishes.SetOfDishesName.Contains(model.SetOfDishesName))
                {
                    result.Add(set_of_dishes.GetViewModel);
                }
            }
            return result;
        }
        public SetOfDishesViewModel? GetElement(SetOfDishesearchModel model)
        {
            if (string.IsNullOrEmpty(model.SetOfDishesName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var set_of_dishes in _source.SetOfDishes)
            {
                if ((!string.IsNullOrEmpty(model.SetOfDishesName) &&
                set_of_dishes.SetOfDishesName == model.SetOfDishesName) ||
                (model.Id.HasValue && set_of_dishes.Id == model.Id))
                {
                    return set_of_dishes.GetViewModel;
                }
            }
            return null;
        }
        public SetOfDishesViewModel? Insert(SetOfDishesBindingModel model)
        {
            model.Id = 1;
            foreach (var set_of_dishes in _source.SetOfDishes)
            {
                if (model.Id <= set_of_dishes.Id)
                {
                    model.Id = set_of_dishes.Id + 1;
                }
            }
            var newSetOfDishes = SetOfDishes.Create(model);
            if (newSetOfDishes == null)
            {
                return null;
            }
            _source.SetOfDishes.Add(newSetOfDishes);
            return newSetOfDishes.GetViewModel;
        }
        public SetOfDishesViewModel? Update(SetOfDishesBindingModel model)
        {
            foreach (var set_of_dishes in _source.SetOfDishes)
            {
                if (set_of_dishes.Id == model.Id)
                {
                    set_of_dishes.Update(model);
                    return set_of_dishes.GetViewModel;
                }
            }
            return null;
        }
        public SetOfDishesViewModel? Delete(SetOfDishesBindingModel model)
        {
            for (int i = 0; i < _source.SetOfDishes.Count; ++i)
            {
                if (_source.SetOfDishes[i].Id == model.Id)
                {
                    var element = _source.SetOfDishes[i];
                    _source.SetOfDishes.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}