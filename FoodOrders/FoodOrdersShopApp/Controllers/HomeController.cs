using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodOrdersShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (APIClient.IsAccessAllowed is false)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<ShopViewModel>>($"api/shop/getshops"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (APIClient.IsAccessAllowed is false)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Введите пароль");
            }
            APIClient.IsAccessAllowed = password.Equals(APIClient.AccessPassword);
            
            if (APIClient.IsAccessAllowed is false)
            {
                throw new Exception("Неверный пароль");
            }
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(string shopname, string address, int maxCount)
        {
            if (APIClient.IsAccessAllowed is false)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (maxCount <= 0)
            {
                throw new Exception("Количество и сумма должны быть больше 0");
            }
            if (string.IsNullOrEmpty(shopname))
            {
                throw new Exception($"Имя магазина не должно быть пустым");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception($"Адрес магазина не должен быть пустым");
            }
            APIClient.PostRequest("api/shop/createshop", new ShopBindingModel
            {
                ShopName = shopname,
                Address = address,
                Capacity = maxCount,
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public Tuple<string, ShopViewModel>? GetTableDishesFromShop(int shop)
        {
            var result = APIClient.GetRequest<Tuple<ShopViewModel, IEnumerable<DishViewModel>, IEnumerable<int>>?>($"api/shop/getshopwithdishes?id={shop}");
            if (result == null)
            {
                return null;
            }
            var shopModel = result.Item1;
            var resultHtml = "";
            foreach (var (item, count) in result.Item2.Zip(result.Item3))
            {
                resultHtml += "<tr>";
                resultHtml += $"<td>{item?.DishName ?? string.Empty}</td>";
                resultHtml += $"<td>{item?.Price ?? 0}</td>";
                resultHtml += $"<td>{count}</td>";
                resultHtml += "</tr>";
            }
            return Tuple.Create(resultHtml, shopModel);
        }

        [HttpGet]
        public IActionResult Update()
        {
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshops");
            return View();
        }

        [HttpPost]
        public void Update(int shop, string name, string address, int capacity)
        {
            if (APIClient.IsAccessAllowed is false)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception($"Имя магазина не должно быть пустым");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception($"Адрес магазина не должен быть пустым");
            }
            APIClient.PostRequest("api/shop/updateshop", new ShopBindingModel
            {
                Id = shop,
                ShopName = name,
                Address = address,
                Capacity = capacity,
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshops");
            return View();
        }

        [HttpPost]
        public void Delete(int shop)
        {
            if (APIClient.IsAccessAllowed is false)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            APIClient.PostRequest("api/shop/deleteshop", new ShopBindingModel
            {
                Id = shop,
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddDish()
        {
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshops");
            ViewBag.Dishes = APIClient.GetRequest<List<DishViewModel>>("api/main/getdishlist");
            return View();
        }

        [HttpPost]
        public void AddDish(int shop, int dish, int count)
        {
            if (APIClient.IsAccessAllowed is false)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (count <= 0)
            {
                throw new Exception("Количество должно быть больше 0");
            }
            APIClient.PostRequest("api/shop/adddishinshop", Tuple.Create(
                new ShopSearchModel() { Id = shop },
                new DishViewModel() { Id = dish },
                count
            ));
            Response.Redirect("Index");
        }
    }
}
