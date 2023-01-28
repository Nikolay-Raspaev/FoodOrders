
namespace FoodOrdersDataModels.Models
{
    public interface IProductModel : IId
    {
        string ProductName { get; }
        double Price { get; }
        Dictionary<int, (IComponentModel, int)> ProductComponents { get; }
    }
}
