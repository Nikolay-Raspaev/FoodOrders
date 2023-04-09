﻿using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FoodOrdersRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ShopController : Controller
	{
		private readonly ILogger _logger;

		private readonly IShopLogic _logic;

		public ShopController(IShopLogic logic, ILogger<ShopController> logger)
		{
			_logger = logger;
			_logic = logic;
		}

		[HttpGet]
		public List<ShopViewModel>? GetShops() 
		{
			try
			{
				return _logic.ReadList(null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка магазинов");
				throw;
			}
		}

		[HttpGet]
		public Tuple<ShopViewModel, IEnumerable<DishViewModel>, IEnumerable<int>>? GetShopWithDishes(int id)
		{
			try
			{
				
				var shop = _logic.ReadElement(new() { Id = id });
				if (shop == null)
				{
					return null;
				}
				return Tuple.Create(shop,
						shop.ShopDishes.Select(x => new DishViewModel() 
						{ 
							Id = x.Value.Item1.Id,
							Price = x.Value.Item1.Price,
                            DishName = x.Value.Item1.DishName,
						}),
						shop.ShopDishes.Select(x => x.Value.Item2));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения магазина");
				throw;
			}
		}

		[HttpPost]
		public void CRUDShop(Action action)
		{
			try
			{
				action.Invoke();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка операции CRUD - {operation} с магазином", action.Method.Name);
				throw;
			}
		}

		[HttpPost]
		public void UpdateShop(ShopBindingModel model) => CRUDShop(() => _logic.Update(model));
		[HttpPost]
		public void CreateShop(ShopBindingModel model) => CRUDShop(() => _logic.Create(model));
		[HttpPost]
		public void DeleteShop(ShopBindingModel model) => CRUDShop(() => _logic.Delete(model));

		[HttpPost]
		public void AddDishInShop(Tuple<DishViewModel, int> countDishForShop)
		{
			CRUDShop(() => _logic.AddDishes(countDishForShop.Item1, countDishForShop.Item2));
		}
	}
}
