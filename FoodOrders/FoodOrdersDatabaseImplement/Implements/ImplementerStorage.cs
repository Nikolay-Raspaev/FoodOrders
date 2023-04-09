using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;

namespace FoodOrdersDatabaseImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			using var context = new FoodOrdersDatabase();
			var res = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (res != null)
			{
				context.Implementers.Remove(res);
				context.SaveChanges();
			}
			return res?.GetViewModel;
		}

		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			using var context = new FoodOrdersDatabase();
			if (model.Id.HasValue)
				return context.Implementers.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
			if (model.ImplementerFIO != null && model.Password != null)
				return context.Implementers
					.FirstOrDefault(x => x.ImplementerFIO.Equals(model.ImplementerFIO)
									  && x.Password.Equals(model.Password))
					?.GetViewModel;
			if (model.ImplementerFIO != null)
				return context.Implementers.FirstOrDefault(x => x.ImplementerFIO.Equals(model.ImplementerFIO))?.GetViewModel;
			return null;
		}

		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			if (model == null)
			{
				return new();
			}
			if (model.Id.HasValue)
			{
				var res = GetElement(model);
				return res != null ? new() { res } : new();
			}
			if (model.ImplementerFIO != null) // На случай если фио не будет уникальным (по заданию оно уникально)
			{
				using var context = new FoodOrdersDatabase();
				return context.Implementers
					.Where(x => x.ImplementerFIO.Equals(model.ImplementerFIO))
					.Select(x => x.GetViewModel)
					.ToList();
			}
			return new();
		}

		public List<ImplementerViewModel> GetFullList()
		{
			using var context = new FoodOrdersDatabase();
			return context.Implementers.Select(x => x.GetViewModel).ToList();
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			using var context = new FoodOrdersDatabase();
			var res = Implementer.Create(model);
			if (res != null)
			{
				context.Implementers.Add(res);
				context.SaveChanges();
			}
			return res?.GetViewModel;	
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			using var context = new FoodOrdersDatabase();
			var res = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (res != null)
			{
				res.Update(model);
				context.SaveChanges();
			}
			return res?.GetViewModel;
		}
	}
}
