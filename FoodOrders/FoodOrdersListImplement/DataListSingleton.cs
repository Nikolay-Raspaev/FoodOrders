using FoodOrdersListImplement.Models;

namespace FoodOrdersListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;
        public List<Dish> Dishes { get; set; }
        public List<Order> Orders { get; set; }
        public List<SetOfDishes> SetOfDishes { get; set; }
        private DataListSingleton()
        {
            Dishes = new List<Dish>();
            Orders = new List<Order>();
            SetOfDishes = new List<SetOfDishes>();
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