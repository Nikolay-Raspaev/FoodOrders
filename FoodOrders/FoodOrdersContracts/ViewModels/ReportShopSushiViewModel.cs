namespace FoodOrdersContracts.ViewModels
{
    public class ReportShopDishViewModel
    {
        public string ShopName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string Dish, int Count)> ListDish { get; set; } = new();
    }
}
