using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdersRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger _logger;

        private readonly IOrderLogic _order;

        private readonly IDishLogic _dish;

        public MainController(ILogger<MainController> logger, IOrderLogic order, IDishLogic dish)
        {
            _logger = logger;
            _order = order;
            _dish = dish;
        }

        [HttpGet]
        public List<DishViewModel>? GetDishList()
        {
            try
            {
                return _dish.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка продуктов");
                throw;
            }
        }

        [HttpGet]
        public DishViewModel? GetDish(int dishId)
        {
            try
            {
                return _dish.ReadElement(new DishSearchModel { Id = dishId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения продукта по id={Id}", dishId);
                throw;
            }
        }

        [HttpGet]
        public List<OrderViewModel>? GetOrders(int clientId)
        {
            try
            {
                return _order.ReadList(new OrderSearchModel { ClientId = clientId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка заказов клиента id={Id}", clientId);
                throw;
            }
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            try
            {
                _order.CreateOrder(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                throw;
            }
        }
    }
}