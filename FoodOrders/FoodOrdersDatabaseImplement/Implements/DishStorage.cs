using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class DishStorage : IDishStorage
    {
		public List<DishViewModel> GetFullList()
		{
			using var context = new FoodOrdersDatabase();
			return context.Dishes
					.Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<DishViewModel> GetFilteredList(DishSearchModel model)
		{
			if (string.IsNullOrEmpty(model.DishName))
			{
				return new();
			}
			using var context = new FoodOrdersDatabase();
			return context.Dishes
					.Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.Where(x => x.DishName.Contains(model.DishName))
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public DishViewModel? GetElement(DishSearchModel model)
		{
			if (string.IsNullOrEmpty(model.DishName) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new FoodOrdersDatabase();
			return context.Dishes
				.Include(x => x.Components)
				.ThenInclude(x => x.Component)
				.FirstOrDefault(x => (!string.IsNullOrEmpty(model.DishName) && x.DishName == model.DishName) ||
								(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public DishViewModel? Insert(DishBindingModel model)
		{
			using var context = new FoodOrdersDatabase();
			var newDish = Dish.Create(context, model);
			if (newDish == null)
			{
				return null;
			}
			context.Dishes.Add(newDish);
			context.SaveChanges();
			return newDish.GetViewModel;
		}

		public DishViewModel? Update(DishBindingModel model)
		{
			using var context = new FoodOrdersDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var dish = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
				if (dish == null)
				{
					return null;
				}
				dish.Update(model);
				context.SaveChanges();
				dish.UpdateComponents(context, model);
				transaction.Commit();
				return dish.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public DishViewModel? Delete(DishBindingModel model)
		{
			using var context = new FoodOrdersDatabase();
			var element = context.Dishes
				.Include(x => x.Components)
                .Include(x => x.Orders)
                .FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Dishes.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}