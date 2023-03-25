using FoodOrdersListImplement.Models;

namespace FoodOrdersListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Dishes = new List<Dish>();
            Clients = new List<Client>();
        }
        public static DataListSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataListSingleton();
            }
            return _instance;
        }
    }
}