namespace FoodOrdersDataModels.Models
{
    public interface IShopModel : IId
    {
        string ShopName { get; }
        string Address { get; }
        DateTime DateOfOpening { get; }
        Dictionary<int, (IDishModel, int)> ShopDishes { get; }
    }
}
