﻿using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using var context = new FoodOrdersDatabase();
            return context.Components
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<ComponentViewModel> GetFilteredList(ComponentSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ComponentName))
            {
                return new();
            }
            using var context = new FoodOrdersDatabase();
            return context.Components
                    .Where(x => x.ComponentName.Contains(model.ComponentName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ComponentViewModel? GetElement(ComponentSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ComponentName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            return context.Components
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ComponentName) && x.ComponentName == model.ComponentName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public ComponentViewModel? Insert(ComponentBindingModel model)
        {
            var newComponent = Component.Create(model);
            if (newComponent == null)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            context.Components.Add(newComponent);
            context.SaveChanges();
            return newComponent.GetViewModel;
        }

        public ComponentViewModel? Update(ComponentBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var component = context.Components.FirstOrDefault(x => x.Id == model.Id);
            if (component == null)
            {
                return null;
            }
            component.Update(model);
            context.SaveChanges();
            return component.GetViewModel;
        }

        public ComponentViewModel? Delete(ComponentBindingModel model)
        {
            using var context = new FoodOrdersDatabase();
            var element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Components.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}