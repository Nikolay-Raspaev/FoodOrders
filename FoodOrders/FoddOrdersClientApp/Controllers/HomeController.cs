using FoodOrdersClientApp.Models;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using FoodOrdersContracts.SearchModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrdersClientApp.Controllers
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
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={APIClient.Client.Id}"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.Client);
        }

        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (APIClient.Client == null)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
            {
                throw new Exception("Введите логин, пароль и ФИО");
            }
            APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
            {
                Id = APIClient.Client.Id,
                ClientFIO = fio,
                Email = login,
                Password = password
            });

            APIClient.Client.ClientFIO = fio;
            APIClient.Client.Email = login;
            APIClient.Client.Password = password;
            Response.Redirect("Index");
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
        public void Enter(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Введите логин и пароль");
            }
            APIClient.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
            if (APIClient.Client == null)
            {
                throw new Exception("Неверный логин/пароль");
            }
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
            {
                throw new Exception("Введите логин, пароль и ФИО");
            }
            APIClient.PostRequest("api/client/register", new ClientBindingModel
            {
                ClientFIO = fio,
                Email = login,
                Password = password
            });
            Response.Redirect("Enter");
            return;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dishes = APIClient.GetRequest<List<DishViewModel>>("api/main/getdishlist");
            return View();
        }

        [HttpPost]
        public void Create(int dish, int count)
        {
            if (APIClient.Client == null)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (count <= 0)
            {
                throw new Exception("Количество и сумма должны быть больше 0");
            }
            APIClient.PostRequest("api/main/createorder", new OrderBindingModel
            {
                ClientId = APIClient.Client.Id,
                DishId = dish,
                Count = count,
                Sum = Calc(count, dish)
            });
            Response.Redirect("Index");
        }

        [HttpPost]
        public double Calc(int count, int dish)
        {
            var prod = APIClient.GetRequest<DishViewModel>($"api/main/getdish?dishId={dish}");
            return count * (prod?.Price ?? 1);
        }

        [HttpGet]
        public IActionResult Mails()
        {
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        /// <summary>
        /// Switches the page.
        /// </summary>
        /// <returns>Возвращает кортеж с таблицой в html, текущей страницей писем, выключать ли кнопку пред. страницы, выключать ли кнопку след. страницы</returns>
        [HttpGet]
        public Tuple<string?, string?, bool, bool>? SwitchPage(bool isNext)
        {
            if (isNext)
            {
                APIClient.CurrentPage++;
            }
            else
            {
                if (APIClient.CurrentPage == 1)
                {
                    return null;
                }
                APIClient.CurrentPage--;
            }

            var res = APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientId={APIClient.Client!.Id}&page={APIClient.CurrentPage}");
            if (isNext && (res == null || res.Count == 0))
            {
                APIClient.CurrentPage--;
                return Tuple.Create<string?, string?, bool, bool>(null, null, APIClient.CurrentPage != 1, false);
            }

            StringBuilder htmlTable = new();
            foreach (var mail in res)
            {
                htmlTable.Append("<tr>" +
                                 $"<td>{mail.DateDelivery}</td>" +
                                 $"<td>{mail.Subject}</td>" +
                                 $"<td>{mail.Body}</td>" +
                                 "<td>" + (mail.HasRead ? "Прочитано" : "Непрочитано") + "</td>" +
                                 $"<td>{mail.Reply}</td>" +
                                 "</tr>");
            }
            return Tuple.Create<string?, string?, bool, bool>(htmlTable.ToString(), APIClient.CurrentPage.ToString(), APIClient.CurrentPage != 1, true);
        }
    }
}