using FoodOrdersListImplement.Models;

namespace FoodOrdersListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dish> Dish { get; set; }
        public List<Shop> Shops { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Dish = new List<Dish>();
            Shops = new List<Shop>();
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