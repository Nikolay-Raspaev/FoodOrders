﻿using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersListImplement.Models;
using System.Collections.Generic;

namespace FoodOrdersListImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		private readonly DataListSingleton _source;
		public ImplementerStorage()
		{
			_source = DataListSingleton.GetInstance();
		}

		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			for (int i = 0; i < _source.Implementers.Count; ++i)
			{
				if (_source.Implementers[i].Id == model.Id)
				{
					var element = _source.Implementers[i];
					_source.Implementers.RemoveAt(i);
					return element.GetViewModel;
				}
			}
			return null;
		}

		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			foreach (var x in _source.Implementers)
			{
				if (model.Id.HasValue && x.Id == model.Id)
					return x.GetViewModel;
				if (model.ImplementerFIO != null && model.Password != null &&
					x.ImplementerFIO.Equals(model.ImplementerFIO) && x.Password.Equals(model.Password))
					return x.GetViewModel;
				if (model.ImplementerFIO != null && x.ImplementerFIO.Equals(model.ImplementerFIO))
					return x.GetViewModel;
			}
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
			// На случай если при расширении проекта фио не будет уникальным
			// (по заданию оно уникально)
			List<ImplementerViewModel> result = new();
			if (model.ImplementerFIO != null) 
			{
				foreach (var implementer in _source.Implementers)
				{
					if (implementer.ImplementerFIO.Equals(model.ImplementerFIO))
					{
						result.Add(implementer.GetViewModel);
					}
				}
			}
			return result;
		}

		public List<ImplementerViewModel> GetFullList()
		{
			var result = new List<ImplementerViewModel>();
			foreach (var implementer in _source.Implementers)
			{
				result.Add(implementer.GetViewModel);
			}
			return result;
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			model.Id = 1;
			foreach (var implementer in _source.Implementers)
			{
				if (model.Id <= implementer.Id)
				{
					model.Id = implementer.Id + 1;
				}
			}
			var res = Implementer.Create(model);
			if (res != null)
			{
				_source.Implementers.Add(res);
			}
			return res?.GetViewModel;
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			foreach (var implementer in _source.Implementers)
			{
				if (implementer.Id == model.Id)
				{
					implementer.Update(model);
					return implementer.GetViewModel;
				}
			}
			return null;
		}
	}
}
