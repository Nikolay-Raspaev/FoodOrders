
namespace FoodOrdersDataModels.Models
{
    public interface IDishModel : IId
    {
        string DishName { get; }
        double Price { get; }
        Dictionary<int, (IComponentModel, int)> DishComponents { get; }
    }
}
